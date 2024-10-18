using AB_APP_Slopes_API.Data;
using AB_APP_Slopes_API.Models;
using AB_APP_Slopes_API.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AB_APP_Slopes_API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ResortsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ResortsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Resort> Resorts()
        {
            List<Resort> resorts = _dbContext.Resorts.ToList();
            return resorts;
        }

        [HttpGet("{id}")]
        public ResortDTO GetResortById(int id)
        {
            ResortDTO resort = _dbContext.Resorts.Select(r => new ResortDTO()
            {
                Id = r.Id,
                Name = r.Name,
                AvalancheRisk = r.AvalancheRisk,
                ImageUrl = r.ImageUrl,
                PassImageUrl = r.PassImageUrl,
            }).FirstOrDefault(r => r.Id == id);
            return resort;
        }

        [HttpGet("GetLifts/{id}")]
        public LiftDTO GetLiftsForResort(int id)
        {
            LiftDTO lift = _dbContext.Lifts.Select(l => new LiftDTO()
            {
                ResortId = l.ResortId,
                Id = l.Id,
                Name = l.Name,
                Elevation = l.Elevation,
                IsOpen = l.IsOpen,

            }).FirstOrDefault(lift => lift.ResortId == id);
            return lift;
        }
    }
}
