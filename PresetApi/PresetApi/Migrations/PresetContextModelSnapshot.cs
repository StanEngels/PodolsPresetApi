﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PresetApi.Models;

namespace PresetApi.Migrations
{
    [DbContext(typeof(PresetApiContext))]
    partial class PresetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PresetApi.Models.Effect", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("EffectType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.ToTable("Effects");
                });

            modelBuilder.Entity("PresetApi.Models.EffectToPreset", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("EffectIdid")
                        .HasColumnType("int");

                    b.Property<int?>("PresetIdid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("EffectIdid");

                    b.HasIndex("PresetIdid");

                    b.ToTable("EffectsToPresets");
                });

            modelBuilder.Entity("PresetApi.Models.Preset", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("accountId")
                        .HasColumnType("int");

                    b.Property<string>("presetName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.ToTable("Presets");
                });

            modelBuilder.Entity("PresetApi.Models.EffectToPreset", b =>
                {
                    b.HasOne("PresetApi.Models.Effect", "EffectId")
                        .WithMany()
                        .HasForeignKey("EffectIdid");

                    b.HasOne("PresetApi.Models.Preset", "PresetId")
                        .WithMany()
                        .HasForeignKey("PresetIdid");
                });
#pragma warning restore 612, 618
        }
    }
}
