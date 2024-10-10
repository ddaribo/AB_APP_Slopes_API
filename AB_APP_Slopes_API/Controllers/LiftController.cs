using AB_APP_Slopes_API.Data;
using AB_APP_Slopes_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace AB_APP_Slopes_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LiftController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public LiftController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Lift> GetAllLifts(int id)
        {
            List<Lift> lifts = _dbContext.Lifts.Where(lift => lift.ResortId == id).ToList();
            return lifts;
        }
    }
}
