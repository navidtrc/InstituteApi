using InstituteApi.Model;
using InstituteApi.ViewModel;
using System;

namespace InstituteApi.Mapper
{
    public static class StudentViewModelExtensions
    {
        public static StudentViewModel ToViewModel(this Student student)
        {
            return new StudentViewModel
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Number = student.Number,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                Birthdate = student.Birthdate,
                Birthdate_Persian = student.Birthdate.ToPersianDateTime()
            };
        }
        public static Student ToModel(this StudentViewModel viewModel)
        {
            return new Student
            {
                Id = viewModel.Id,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Number = viewModel.Number,
                Email = viewModel.Email,
                PhoneNumber = viewModel.PhoneNumber,
                Birthdate = viewModel.Birthdate_Persian.ToGregorianDateTime()
            };
        }
    }
}