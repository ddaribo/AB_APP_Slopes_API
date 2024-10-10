using AB_APP_Slopes_API.Data;
using AB_APP_Slopes_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AB_APP_Slopes_API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ResortController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ResortController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Resort> GetAllResorts()
        {
            List<Resort> resorts = _dbContext.Resorts.ToList();
            return resorts;
        }

        [HttpGet("GetLifts")]
        public IEnumerable<Lift> GetLiftsForResort(int id)
        {
            List<Lift> lifts = _dbContext.Lifts.Where(lift => lift.ResortId == id).ToList();
            return lifts;
        }
    }
}
