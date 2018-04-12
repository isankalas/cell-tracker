﻿// <auto-generated />
using CellTracker.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace CellTracker.Repository.Migrations
{
    [DbContext(typeof(LogDbContext))]
    partial class LogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CellTracker.Repository.Entities.LogRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CellActionTypeString")
                        .IsRequired()
                        .HasColumnName("CellActionType");

                    b.Property<string>("SubscriberId");

                    b.Property<DateTimeOffset>("Timestamp");

                    b.HasKey("Id");

                    b.HasIndex("SubscriberId", "CellActionTypeString");

                    b.ToTable("LogRecords");

                    b.HasDiscriminator<string>("CellActionTypeString").HasValue("LogRecord");
                });

            modelBuilder.Entity("CellTracker.Repository.Entities.CallRecord", b =>
                {
                    b.HasBaseType("CellTracker.Repository.Entities.LogRecord");

                    b.Property<TimeSpan>("Duration");

                    b.ToTable("LogRecords");

                    b.HasDiscriminator().HasValue("Call");
                });

            modelBuilder.Entity("CellTracker.Repository.Entities.SmsRecord", b =>
                {
                    b.HasBaseType("CellTracker.Repository.Entities.LogRecord");


                    b.ToTable("LogRecords");

                    b.HasDiscriminator().HasValue("Sms");
                });
#pragma warning restore 612, 618
        }
    }
}
