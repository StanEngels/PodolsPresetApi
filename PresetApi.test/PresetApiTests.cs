using System;
using PresetApi.Models;
using Xunit;
using System.Collections.Generic;
using PresetApi.Controllers;
using System.Threading.Tasks;
using PresetApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace PresetApi.test
{
    public class PresetApiTests
    {
        [Theory]
        [MemberData(nameof(TestGetAllPresetDataSet))]
        public async void TestGetAllPresetData(List<Preset> expectedPreset)
        {
            //Arange
            PresetsDbAccessMock presetsDbAccessMock = new PresetsDbAccessMock();
            PresetsController presetController = new PresetsController(presetsDbAccessMock);

            //Act
            ActionResult<IList<Preset>> result = await presetController.GetPresets();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.Value[0].presetName, expectedPreset[0].presetName);
            Assert.Equal(result.Value[1].presetName, expectedPreset[1].presetName);
        }

        public static IEnumerable<object[]> TestGetAllPresetDataSet()
        {
            List<object[]> result = new List<object[]>();
            List<Preset> presetList = new List<Preset>();

            Preset preset = new Preset
            {
                presetName = "Test"
            };
            Preset preset2 = new Preset
            {
                presetName = "Test2"
            };

            presetList.Add(preset);
            presetList.Add(preset2);
            result.Add(new object[] { presetList });
            return result;
        }

        public class PresetsDbAccessMock : IPresetDbAccess
        {
            public async Task<List<Preset>> GetPresets()
            {
                List<Preset> testList = new List<Preset>();
                Preset presetReturn = new Preset
                {
                    presetName = "Test"
                };
                Preset presetReturn2 = new Preset
                {
                    presetName = "Test2"
                };
                testList.Add(presetReturn);
                testList.Add(presetReturn2);
                return testList;
            }

            public Task<Preset> DeletePreset(Preset preset)
            {
                throw new NotImplementedException();
            }

            public Task<Preset> GetPreset(int id)
            {
                throw new NotImplementedException();
            }

            public Task<Preset> PostPreset(Preset preset)
            {
                throw new NotImplementedException();
            }

            public Task<Preset> PresetExists(int id)
            {
                throw new NotImplementedException();
            }

            public Task<Preset> PutPreset(int id, Preset preset)
            {
                throw new NotImplementedException();
            }
        }
    }
}
