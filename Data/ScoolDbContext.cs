using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Enitities;

namespace WebApi.Data
{
    public class ScoolDbContext : DbContext
    {
        public ScoolDbContext(DbContextOptions<ScoolDbContext> options) : base(options)
        {

        }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassRoom>().HasData(new ClassRoom
            {
                Id = Guid.Parse("6e80e548-af1e-4604-8271-03c99dcf3741"),
                Name = "一年级一班",
                Introduction = "我们班级有很多可爱的小学生"

            });
            modelBuilder.Entity<ClassRoom>().HasData(new ClassRoom
            {
                Id = Guid.Parse("8e59c334-6c2a-45c6-8e8e-7c72d2408abb"),
                Name = "一年级二班",
                Introduction = "班级十分厉害，学习成绩优秀"

            });
            modelBuilder.Entity<ClassRoom>().HasData(new ClassRoom
            {
                Id = Guid.Parse("ea5b68ae-ed50-4dba-83f6-b21130136c18"),
                Name = "一年级三班",
                Introduction = "班级都是差生，最弱班级"

            });
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = Guid.Parse("1c711b7c-d5a4-438e-8af8-3e71e9657658"),
                ClassId = Guid.Parse("6e80e548-af1e-4604-8271-03c99dcf3741"),
                FirstName = "王",
                LastName = "明",
                NumberNo = "001",
                Gender = Gender.男
            });
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = Guid.Parse("23614990-836f-433c-94b6-198db3664596"),
                ClassId = Guid.Parse("6e80e548-af1e-4604-8271-03c99dcf3741"),
                FirstName = "李",
                LastName = "娟",
                NumberNo = "002",
                Gender = Gender.女
            });
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = Guid.Parse("52595ba2-763b-49d5-b57c-7956eb1aae7c"),
                ClassId = Guid.Parse("8e59c334-6c2a-45c6-8e8e-7c72d2408abb"),
                FirstName = "陈",
                LastName = "二狗",
                NumberNo = "003",
                Gender = Gender.男
            });
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = Guid.Parse("794cd2a0-ce27-4183-a569-defa645fcbf1"),
                ClassId = Guid.Parse("8e59c334-6c2a-45c6-8e8e-7c72d2408abb"),
                FirstName = "小",
                LastName = "风",
                NumberNo = "004",
                Gender = Gender.女
            });
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = Guid.Parse("88603bc0-7614-47a8-9521-c684b32cf83e"),
                ClassId = Guid.Parse("ea5b68ae-ed50-4dba-83f6-b21130136c18"),
                FirstName = "陈",
                LastName = "小兰",
                NumberNo = "004",
                Gender = Gender.女
            });
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = Guid.Parse("df4cf4c1-3cc3-4e82-90aa-0b414c164b06"),
                ClassId = Guid.Parse("ea5b68ae-ed50-4dba-83f6-b21130136c18"),
                FirstName = "小",
                LastName = "吴",
                NumberNo = "005",
                Gender = Gender.女
            });
        }

    }
}
