using Microsoft.AspNetCore.Mvc;
using Web.EntitiesDTO;
using Web.Services;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService studentService;

    public StudentController(IStudentService studentService)
    {
        this.studentService = studentService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(AddStudent request)
    {
        string? error = await studentService.CreateAsync(request);
        if(error != null) return BadRequest(error);
        return Ok("Success");
    }
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await studentService.GetAllAsync());
    }
}
