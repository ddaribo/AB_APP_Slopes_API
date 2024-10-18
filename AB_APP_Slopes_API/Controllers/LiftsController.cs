using AB_APP_Slopes_API.Data;
using AB_APP_Slopes_API.Models;
using AB_APP_Slopes_API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AB_APP_Slopes_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LiftsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public LiftsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<LiftDTO> GetLifts(int id)
        {
            List<LiftDTO> lifts = _dbContext.Lifts.Where(lift => lift.ResortId == id).Select(l => new LiftDTO()
            {
                ResortId = l.ResortId,
                Id = l.Id,
                Name = l.Name,
                Elevation = l.Elevation,
                IsOpen = l.IsOpen,

            }).ToList();
            return lifts;
        }
    }
}
