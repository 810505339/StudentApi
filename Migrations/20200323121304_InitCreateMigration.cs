using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class InitCreateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "classroom",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Introduction = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classroom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClassId = table.Column<Guid>(nullable: false),
                    NumberNo = table.Column<string>(maxLength: 10, nullable: false),
                    FirstName = table.Column<string>(maxLength: 10, nullable: false),
                    LastName = table.Column<string>(maxLength: 10, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    ClassRoomId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_student_classroom_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "classroom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "classroom",
                columns: new[] { "Id", "Introduction", "Name" },
                values: new object[,]
                {
                    { new Guid("6e80e548-af1e-4604-8271-03c99dcf3741"), "我们班级有很多可爱的小学生", "一年级一班" },
                    { new Guid("8e59c334-6c2a-45c6-8e8e-7c72d2408abb"), "班级十分厉害，学习成绩优秀", "一年级二班" },
                    { new Guid("ea5b68ae-ed50-4dba-83f6-b21130136c18"), "班级都是差生，最弱班级", "一年级三班" }
                });

            migrationBuilder.InsertData(
                table: "student",
                columns: new[] { "Id", "ClassId", "ClassRoomId", "FirstName", "Gender", "LastName", "NumberNo" },
                values: new object[,]
                {
                    { new Guid("1c711b7c-d5a4-438e-8af8-3e71e9657658"), new Guid("6e80e548-af1e-4604-8271-03c99dcf3741"), null, "王", 1, "明", "001" },
                    { new Guid("23614990-836f-433c-94b6-198db3664596"), new Guid("6e80e548-af1e-4604-8271-03c99dcf3741"), null, "李", 2, "娟", "002" },
                    { new Guid("52595ba2-763b-49d5-b57c-7956eb1aae7c"), new Guid("8e59c334-6c2a-45c6-8e8e-7c72d2408abb"), null, "陈", 1, "二狗", "003" },
                    { new Guid("794cd2a0-ce27-4183-a569-defa645fcbf1"), new Guid("8e59c334-6c2a-45c6-8e8e-7c72d2408abb"), null, "小", 2, "风", "004" },
                    { new Guid("88603bc0-7614-47a8-9521-c684b32cf83e"), new Guid("ea5b68ae-ed50-4dba-83f6-b21130136c18"), null, "陈", 2, "小兰", "004" },
                    { new Guid("df4cf4c1-3cc3-4e82-90aa-0b414c164b06"), new Guid("ea5b68ae-ed50-4dba-83f6-b21130136c18"), null, "小", 2, "吴", "005" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_student_ClassRoomId",
                table: "student",
                column: "ClassRoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "classroom");
        }
    }
}
