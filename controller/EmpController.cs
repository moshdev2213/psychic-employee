using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Api_2._0;

// localhost:xxxx/api/emp
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class EmpController : ControllerBase
{

    private readonly AppDbContext dbContext;

    public EmpController(AppDbContext appDbContext)
    {
        dbContext = appDbContext;
    }

    [HttpGet]
    public IActionResult GetAllEmp()
    {
        var allEmp = dbContext.Employees.ToList();
        return Ok(allEmp);
    }

    [HttpGet]
    [Route("{id:int}")]
    public IActionResult getEmpById(int id){
        var employee = dbContext.Employees.Find(id);
        if(employee is null){
            return NotFound("Employee Not Found");
        }
        return Ok(employee);
    }

    [HttpPost]
    public IActionResult AddEmp(AddEmpDto addEmpDto){
        var employeeEntity = new Employee() {
            Name = addEmpDto.Name,
            Email = addEmpDto.Email,
            Phone = addEmpDto.Phone,
            Salary = addEmpDto.Salary
        };
        dbContext.Employees.Add(employeeEntity);
        dbContext.SaveChanges();

        return Ok(employeeEntity);
    }

    [HttpPut]
    [Route("{id;int}")]
    public IActionResult UpdateEmp(int id , UpdateEmpDto updateEmpDto){
        var employee = dbContext.Employees.Find(id);
        if(employee is null){
            return NotFound();
        }
        employee.Name = updateEmpDto.Name;
        employee.Email = updateEmpDto.Email;
        employee.Phone = updateEmpDto.Phone;
        employee.Salary = updateEmpDto.Salary;

        dbContext.SaveChanges();
        return Ok(employee);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public IActionResult deleteEmp(int id){
        var employee = dbContext.Employees.Find(id);
        if(employee is null){
            return NotFound();
        }
        dbContext.Employees.Remove(employee);
        dbContext.SaveChanges();

        return Ok();
    }

}