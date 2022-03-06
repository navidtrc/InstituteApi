using InstituteApi.Common.Enums;
using InstituteApi.Model;
using InstituteApi.ViewModel;
using System;
using System.Linq;

namespace InstituteApi.Mapper
{
    public static class CourseViewModelExtensions
    {
        public static CourseViewModel ToViewModel(this Course course)
        {
            return new CourseViewModel
            {
                Id = course.Id,
                Title = course.Title,
                Duration = course.Duration,
                HoldingDays = course.HoldingDays.ToWeekList(),
                HourBegin = course.HourBegin,
                HourEnd = course.HourEnd,
                Instructor = course.Instructor,
                StartDate = course.StartDate,
                StartDate_Persian = course.StartDate.ToPersianDateTime()
            };
        }
        public static Course ToModel(this CourseViewModel viewModel)
        {
            return new Course
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                Duration = viewModel.Duration,
                HoldingDays = viewModel.HoldingDays.ToWeekModel(),
                HourBegin = viewModel.HourBegin,
                HourEnd = viewModel.HourEnd,
                Instructor = viewModel.Instructor,
                StartDate = viewModel.StartDate_Persian.ToGregorianDateTime(),
            };
        }
    }
}
