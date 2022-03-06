using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InstituteApi.Model
{
    public class Student : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");
            builder.HasMany(m => m.StudentCourses)
                .WithOne(o => o.Student)
                .HasForeignKey(o => o.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}