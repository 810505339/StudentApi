﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Data;

namespace WebApi.Migrations
{
    [DbContext(typeof(ScoolDbContext))]
    [Migration("20200323121304_InitCreateMigration")]
    partial class InitCreateMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebApi.Enitities.ClassRoom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Introduction")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("classroom");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6e80e548-af1e-4604-8271-03c99dcf3741"),
                            Introduction = "我们班级有很多可爱的小学生",
                            Name = "一年级一班"
                        },
                        new
                        {
                            Id = new Guid("8e59c334-6c2a-45c6-8e8e-7c72d2408abb"),
                            Introduction = "班级十分厉害，学习成绩优秀",
                            Name = "一年级二班"
                        },
                        new
                        {
                            Id = new Guid("ea5b68ae-ed50-4dba-83f6-b21130136c18"),
                            Introduction = "班级都是差生，最弱班级",
                            Name = "一年级三班"
                        });
                });

            modelBuilder.Entity("WebApi.Enitities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ClassId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ClassRoomId")
                        .HasColumnType("char(36)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<string>("NumberNo")
                        .IsRequired()
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("ClassRoomId");

                    b.ToTable("student");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1c711b7c-d5a4-438e-8af8-3e71e9657658"),
                            ClassId = new Guid("6e80e548-af1e-4604-8271-03c99dcf3741"),
                            FirstName = "王",
                            Gender = 1,
                            LastName = "明",
                            NumberNo = "001"
                        },
                        new
                        {
                            Id = new Guid("23614990-836f-433c-94b6-198db3664596"),
                            ClassId = new Guid("6e80e548-af1e-4604-8271-03c99dcf3741"),
                            FirstName = "李",
                            Gender = 2,
                            LastName = "娟",
                            NumberNo = "002"
                        },
                        new
                        {
                            Id = new Guid("52595ba2-763b-49d5-b57c-7956eb1aae7c"),
                            ClassId = new Guid("8e59c334-6c2a-45c6-8e8e-7c72d2408abb"),
                            FirstName = "陈",
                            Gender = 1,
                            LastName = "二狗",
                            NumberNo = "003"
                        },
                        new
                        {
                            Id = new Guid("794cd2a0-ce27-4183-a569-defa645fcbf1"),
                            ClassId = new Guid("8e59c334-6c2a-45c6-8e8e-7c72d2408abb"),
                            FirstName = "小",
                            Gender = 2,
                            LastName = "风",
                            NumberNo = "004"
                        },
                        new
                        {
                            Id = new Guid("88603bc0-7614-47a8-9521-c684b32cf83e"),
                            ClassId = new Guid("ea5b68ae-ed50-4dba-83f6-b21130136c18"),
                            FirstName = "陈",
                            Gender = 2,
                            LastName = "小兰",
                            NumberNo = "004"
                        },
                        new
                        {
                            Id = new Guid("df4cf4c1-3cc3-4e82-90aa-0b414c164b06"),
                            ClassId = new Guid("ea5b68ae-ed50-4dba-83f6-b21130136c18"),
                            FirstName = "小",
                            Gender = 2,
                            LastName = "吴",
                            NumberNo = "005"
                        });
                });

            modelBuilder.Entity("WebApi.Enitities.Student", b =>
                {
                    b.HasOne("WebApi.Enitities.ClassRoom", "ClassRoom")
                        .WithMany("MyProperty")
                        .HasForeignKey("ClassRoomId");
                });
#pragma warning restore 612, 618
        }
    }
}
