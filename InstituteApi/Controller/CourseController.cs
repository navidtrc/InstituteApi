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
    public class CourseController : BaseController
    {
        public CourseController(DataContext context) : base(context)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var result = await _context.Courses.AsNoTracking()
                .Select(s => s.ToViewModel()).ToListAsync(cancellationToken);
            if (result.Count == 0)
                return NotFound();
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetById(int courseId, CancellationToken cancellationToken)
        {
            var result = await _context.Courses
                .SingleOrDefaultAsync(s => s.Id == courseId, cancellationToken);
            if (result == null)
                return NotFound();
            return Ok(result.ToViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Post(CourseViewModel viewModel, CancellationToken cancellationToken)
        {
            await _context.Courses.AddAsync(viewModel.ToModel(), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(CourseViewModel viewModel, CancellationToken cancellationToken)
        {
            _context.Courses.Update(viewModel.ToModel());
            await _context.SaveChangesAsync(cancellationToken);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var model = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(model);
            await _context.SaveChangesAsync(cancellationToken);
            return Ok();
        }
    }
}
