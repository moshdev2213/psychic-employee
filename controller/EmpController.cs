using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Api_2._0;

// localhost:xxxx/api/emp
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class EmpController : ControllerBase
{

    private readonly IEmpService _empService;

    public EmpController(IEmpService empService)
    {
        _empService = empService;
    }

    [HttpGet]
    public IActionResult GetAllEmp()
    {
        var allEmp = _empService.GetAllEmp();
        return Ok(allEmp);
    }

    [HttpGet]
    [Route("{id:int}")]
    public IActionResult GetEmpById(int id)
    {
        var employee = _empService.GetEmpById(id);
        if (employee is null)
        {
            return NotFound("Employee Not Found");
        }
        return Ok(employee);
    }

    [HttpPost]
    public IActionResult AddEmp(AddEmpDto addEmpDto)
    {
        var addedEmp = _empService.AddEmp(addEmpDto);
        return Ok(addedEmp);
    }

    [HttpPut]
    [Route("{id;int}")]
    public IActionResult UpdateEmp(int id, UpdateEmpDto updateEmpDto)
    {
        var updatedEmp = _empService.UpdateEmp(id, updateEmpDto);
        if (updatedEmp == null)
        {
            return NotFound();
        }
        return Ok(updatedEmp);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public IActionResult DeleteEmp(int id)
    {
        var result = _empService.DeleteEmp(id);
        if (result)
        {
            return Ok();
        }
        return NotFound();
    }

}