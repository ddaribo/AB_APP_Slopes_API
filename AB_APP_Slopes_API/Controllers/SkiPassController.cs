using AB_APP_Slopes_API.Data;
using AB_APP_Slopes_API.Models.DTOs;
using AB_APP_Slopes_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class SkiPassController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ApplicationDbContext _dbContext;

    public SkiPassController(UserManager<IdentityUser> userManager, ApplicationDbContext dbContext)
    {
        _userManager = userManager;
        _dbContext = dbContext;
    }

    [HttpGet("{id}")]
    public SkiPassDto GetSkiPassById(string id)
    {
        var pass = _dbContext.SkiPasses.Select(sp => new SkiPassDto()
        {
            Id = sp.ID,
            UserId= sp.User.Id,
            ResortID = sp.ResortId,
            IsReloadable = sp.IsReloadable,
            IsActive = sp.IsActive,
            FirstName = sp.FirstName,
            LastName = sp.LastName
        }).FirstOrDefault(sp => sp.Id == id);
        return pass;
    }

    [HttpGet("SkiPassValidationItems/{id}")]
    public List<SkiPassValidationItem> GetSkiPassValidationItems(string id)
    {
        List<SkiPassValidationItem> items = _dbContext.SkiPassValidationItems.Where(item => item.SkiPass.ID == id).ToList();
        return items;
    }

    [HttpGet("LiftStatsForPass/{id}")]
    public List<SkiPassStatsDto> GetLiftsStatsForPass(string id)
    {
        var pass = _dbContext.SkiPasses.FirstOrDefault(sp => sp.ID == id);
        var liftStats = _dbContext.SkiPassValidationItems
                          .Where(spvi => spvi.SkiPassId == pass.ID) // Filter by SkiPass ID
                          .GroupBy(spvi => spvi.LiftId)
                          .Select(group => new SkiPassStatsDto()
                          {
                              LiftId = group.Key,
                              LiftName = _dbContext.Lifts.FirstOrDefault(l => l.Id == group.Key).Name, 
                              Count = group.Count()
                          }).ToList();
        return liftStats;
    }

    [HttpGet("UserSkiPasses/{id}")]
    public List<SkiPassDto> GetSkiPassForUser(string id)
    {
        var passes = _dbContext.SkiPasses.Where(skipass => skipass.User.Id == id)
            .Select(sp => new SkiPassDto
            {
                Id = sp.ID,
                UserId = sp.User.Id,
                ResortID = sp.ResortId,
                IsReloadable = sp.IsReloadable,
                IsActive = sp.IsActive,
                FirstName = sp.FirstName,
                LastName = sp.LastName
            }).ToList();

        return passes;
    }

    [HttpPost]
    public ActionResponseDTO AddSkiPassToUser([FromBody] SkiPassDto skiPassDto)
    {
        var user = _userManager.Users.FirstOrDefault(u => u.Id == skiPassDto.UserId);
        if (user == null)
        {
            return new ActionResponseDTO() { Response = "User pass not found" };
        }

        var skiPass = new SkiPass
        {
            ID = Guid.NewGuid().ToString(),
            User = user,
            ResortId = skiPassDto.ResortID,
            IsReloadable = skiPassDto.IsReloadable,
            IsActive = skiPassDto.IsActive,
            FirstName = skiPassDto.FirstName,
            LastName = skiPassDto.LastName
        };

        _dbContext.SkiPasses.Add(skiPass);
        _dbContext.SaveChanges();

        return new ActionResponseDTO() { Response = "Ski pass added" };
    }

    [HttpDelete("DeleteSkiPass/{id}")]
    public ActionResponseDTO DeleteSkiPass(string id)
    {
        var skiPass = _dbContext.SkiPasses.FirstOrDefault(sp => sp.ID == id);

        if (skiPass == null)
        {
            return new ActionResponseDTO() { Response = "Ski pass not found" };
        }

        _dbContext.SkiPasses.Remove(skiPass);
        _dbContext.SaveChanges();

        return new ActionResponseDTO() { Response = "Successfully deleted"};
    }
}
