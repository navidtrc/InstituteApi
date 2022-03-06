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
    public class StudentController : BaseController
    {
        public StudentController(DataContext context) : base(context)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var result = await _context.Students.AsNoTracking()
                .Select(s => s.ToViewModel()).ToListAsync(cancellationToken);
            if (result.Count == 0)
                return NotFound();
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetById(int studentId, CancellationToken cancellationToken)
        {
            var result = await _context.Students
                .SingleOrDefaultAsync(s => s.Id == studentId, cancellationToken);
            if (result == null)
                return NotFound();
            return Ok(result.ToViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Post(StudentViewModel viewModel, CancellationToken cancellationToken)
        {
            await _context.Students.AddAsync(viewModel.ToModel(), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(StudentViewModel viewModel, CancellationToken cancellationToken)
        {
            _context.Students.Update(viewModel.ToModel());
            await _context.SaveChangesAsync(cancellationToken);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var model = await _context.Students.FindAsync(id);
            _context.Students.Remove(model);
            await _context.SaveChangesAsync(cancellationToken);
            return Ok();
        }
    }
}
