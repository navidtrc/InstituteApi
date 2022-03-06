using InstituteApi.Common.Filters;
using InstituteApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstituteApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiResultFilter]
    public class BaseController : ControllerBase
    {
        protected readonly DataContext _context;
        public BaseController(DataContext context)
        {
            _context = context;
        }
    }
}
