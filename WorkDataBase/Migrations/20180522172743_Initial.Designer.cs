﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WorkDataBase.Models;

namespace WorkDataBase.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20180522172743_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WorkDataBase.Models.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("WorkDataBase.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<Guid?>("CarId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WorkDataBase.Models.User", b =>
                {
                    b.HasOne("WorkDataBase.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId");
                });
#pragma warning restore 612, 618
        }
    }
}
