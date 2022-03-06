using InstituteApi.Common.Filters;
using InstituteApi.Mapper;
using InstituteApi.Model;
using InstituteApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InstituteApi.Controller
{
    [ApiController]
    [ApiResultFilter]
    public class StudentCourseController : ControllerBase
    {
        private readonly DataContext _context;
        public StudentCourseController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/[controller]/[action]")]
        public async Task<IActionResult> GetStudentsByCourseId(int courseId, CancellationToken cancellationToken)
        {
            var result = await _context.StudentCourses
                .Include(i => i.Student)
                .AsNoTracking()
                .Where(w => w.CourseId == courseId)
                .Select(s => s.Student.ToViewModel())
                .ToListAsync(cancellationToken);
            if (result.Count == 0)
                return NotFound();
            return Ok(result);
        }

        [HttpGet]
        [Route("api/[controller]/[action]")]
        public async Task<IActionResult> GetCoursesByStudentId(int studentId, CancellationToken cancellationToken)
        {
            var result = await _context.StudentCourses
                .Include(i => i.Course)
                .AsNoTracking()
                .Where(w => w.StudentId == studentId)
                .Select(s => s.Course.ToViewModel())
                .ToListAsync(cancellationToken);
            if (result.Count == 0)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        [Route("api/[controller]/[action]")]
        public async Task<IActionResult> Post(StudentCourseViewModel viewModel, CancellationToken cancellationToken)
        {
            await _context.StudentCourses.AddAsync(new StudentCourse
            {
                CourseId = viewModel.CourseId,
                StudentId = viewModel.StudentId,
            }, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Ok();
        }

        [HttpDelete]
        [Route("api/[controller]/[action]")]
        public async Task<IActionResult> Delete(StudentCourseViewModel viewModel, CancellationToken cancellationToken)
        {
            var model = await _context.StudentCourses
                .SingleOrDefaultAsync(s => s.CourseId == viewModel.CourseId && s.StudentId == viewModel.StudentId, cancellationToken);
            if (model == null)
                return NotFound();
            _context.StudentCourses.Remove(model);
            await _context.SaveChangesAsync(cancellationToken);
            return Ok();
        }

    }
}
