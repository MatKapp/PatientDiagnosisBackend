﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PatientDiagnosis.Examinations.Service.Models;

namespace PatientDiagnosis.Examinations.Service.Migrations
{
    [DbContext(typeof(ExaminationDbContext))]
    [Migration("20200927070141_AddmisionDischardeDatesAddedtoExamination")]
    partial class AddmisionDischardeDatesAddedtoExamination
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("PatientDiagnosis.Common.Models.Entities.Examination", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("AdmissionDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool?>("AtrialFibrillation")
                        .HasColumnName("atrial_fibrillation")
                        .HasColumnType("boolean");

                    b.Property<bool?>("BodyWeakness")
                        .HasColumnName("body_weakness")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("DischargeDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<float>("FirstClassPrediction")
                        .HasColumnType("real");

                    b.Property<bool?>("FirstTia")
                        .HasColumnName("first_tia")
                        .HasColumnType("boolean");

                    b.Property<bool?>("GaitDisturb")
                        .HasColumnName("gait_disturb")
                        .HasColumnType("boolean");

                    b.Property<bool?>("HighGlucose")
                        .HasColumnName("high_glucose")
                        .HasColumnType("boolean");

                    b.Property<int?>("Infraction")
                        .HasColumnName("infraction")
                        .HasColumnType("integer");

                    b.Property<int?>("InitialDbp")
                        .HasColumnName("initial_dbp")
                        .HasColumnType("integer");

                    b.Property<int?>("PatientId")
                        .HasColumnName("patient_id")
                        .HasColumnType("integer");

                    b.Property<float>("SecondClassPrediction")
                        .HasColumnType("real");

                    b.Property<bool?>("SpeechDif")
                        .HasColumnName("speech_dif")
                        .HasColumnType("boolean");

                    b.Property<bool?>("TiaInTwoWeeksOccured")
                        .HasColumnType("boolean");

                    b.Property<bool?>("Vertigo")
                        .HasColumnName("vertigo")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Examinations");
                });
#pragma warning restore 612, 618
        }
    }
}
