using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InstituteApi.Model
{
    public class Course : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Instructor { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public int HoldingDays { get; set; }

        [Required]
        public TimeSpan HourBegin { get; set; }

        [Required]
        public TimeSpan HourEnd { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course");
            builder.HasMany(m => m.StudentCourses)
                .WithOne(o => o.Course)
                .HasForeignKey(o => o.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
