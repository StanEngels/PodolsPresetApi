using System;
using PresetApi.Models;
using Xunit;
using System.Collections.Generic;
using PresetApi.Controllers;
using System.Threading.Tasks;
using PresetApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace PresetApi.ContentTests
{
    public class LaunchSettingsFixture : IDisposable
    {
        public LaunchSettingsFixture()
        {
            using (var file = File.OpenText("Properties\\launchSettings.json"))
            {
                var reader = new JsonTextReader(file);
                var jObject = JObject.Load(reader);

                var variables = jObject
                    .GetValue("profiles")
                    //select a proper profile here
                    .SelectMany(profiles => profiles.Children())
                    .SelectMany(profile => profile.Children<JProperty>())
                    .Where(prop => prop.Name == "environmentVariables")
                    .SelectMany(prop => prop.Value.Children<JProperty>())
                    .ToList();

                foreach (var variable in variables)
                {
                    Environment.SetEnvironmentVariable(variable.Name, variable.Value.ToString());
                }
            }
        }

        public void Dispose()
        {
            // ... clean up
        }
    }

    public class PresetApiContentTests : IClassFixture<WebApplicationFactory<PresetApi.Startup>>
    {
        private HttpClient Client { get; }

        public PresetApiContentTests(WebApplicationFactory<PresetApi.Startup> fixture)
        {
            Client = fixture.CreateClient();
            LaunchSettingsFixture launchSettingsFixture = new LaunchSettingsFixture();
        }

        //check if json response
        [Fact]
        public async Task TestExpectedJsonFromApi()
        {

            string schemaJson = @"{
                  'properties': {
                    'id': {'type': 'integer' },
                    'accountId': {'type': 'integer'},
                    'presetName': {'type': 'string'}
                  }
            }";

            HttpResponseMessage response = await Client.GetAsync("/api/presets");

            string responseJson = await response.Content.ReadAsStringAsync();

            //string responseJson = response.Content.ToString();

            JSchema schema = JSchema.Parse(schemaJson);

            JArray preset = JArray.Parse(responseJson);

            bool valid = preset.IsValid(schema); 

            Assert.True(valid);
        }
    }
}
