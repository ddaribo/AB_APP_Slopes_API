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

    [HttpGet]
    public IActionResult GetSkiPass([FromQuery] string id)
    {
        var pass = _dbContext.SkiPasses.FirstOrDefault(sp => sp.ID == id);

        if (pass == null)
        {
            return NotFound(new { message = "Ski pass not found" });
        }

        return Ok(pass);
    }

    [HttpGet("SkiPassValidationItems")]
    public IActionResult GetSkiPassValidationItems(string id)
    {
        var items = _dbContext.SkiPassValidationItems.Where(item => item.SkiPass.ID == id).ToList();
        return Ok(items);
    }

    [HttpGet("UserSkiPasses")]
    public IActionResult GetSkiPassForUser(string id)
    {
        var passes = _dbContext.SkiPasses.Where(skipass => skipass.User.Id == id)
            .Select(sp => new SkiPassDto
            {
                Id = sp.ID,
                UserId = sp.User.Id,
                ResortID = sp.Resort,
                IsReloadable = sp.IsReloadable,
                IsActive = sp.IsActive,
                FirstName = sp.FirstName,
                LastName = sp.LastName
            }).ToList();

        return Ok(passes);
    }

    [HttpPost]
    public IActionResult AddSkiPassToUser([FromBody] SkiPassDto skiPassDto)
    {
        var user = _userManager.Users.FirstOrDefault(u => u.Id == skiPassDto.UserId);
        if (user == null)
        {
            return NotFound(new { message = "User not found." });
        }

        var skiPass = new SkiPass
        {
            ID = Guid.NewGuid().ToString(),
            User = user,
            Resort = skiPassDto.ResortID,
            IsReloadable = skiPassDto.IsReloadable,
            IsActive = skiPassDto.IsActive,
            FirstName = skiPassDto.FirstName,
            LastName = skiPassDto.LastName
        };

        _dbContext.SkiPasses.Add(skiPass);
        _dbContext.SaveChanges();

        return Ok(new { message = "Ski pass added successfully" });
    }

    [HttpDelete("DeleteSkiPass/{id}")]
    public IActionResult DeleteSkiPass(string id)
    {
        var skiPass = _dbContext.SkiPasses.FirstOrDefault(sp => sp.ID == id);

        if (skiPass == null)
        {
            return NotFound(new { message = "Ski pass not found" });
        }

        _dbContext.SkiPasses.Remove(skiPass);
        _dbContext.SaveChanges();

        return Ok(new { message = "Ski pass deleted successfully" });
    }
}
