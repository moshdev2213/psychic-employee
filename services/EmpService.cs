using Api_2;
using Api_2._0;

public class EmpService : IEmpService
{
    private readonly AppDbContext appDbContext;
    public EmpService(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public Employee AddEmp(AddEmpDto addEmpDto)
    {
        var employeeEntity = new Employee
        {
            Name = addEmpDto.Name,
            Email = addEmpDto.Email,
            Phone = addEmpDto.Phone,
            Salary = addEmpDto.Salary
        };
        appDbContext.Employees.Add(employeeEntity);
        appDbContext.SaveChanges();
        return employeeEntity;
    }

    public Boolean DeleteEmp(int id)
    {
        var employee = appDbContext.Employees.Find(id);
        if(employee is null){
            return false;
        }
        appDbContext.Employees.Remove(employee);
        appDbContext.SaveChanges();
        return true;
    }

    public IEnumerable<Employee> GetAllEmp()
    {
        return appDbContext.Employees.ToList();
    }

    public Employee GetEmpById(int id)
    {
        var employee = appDbContext.Employees.Find(id);
        if (employee is null)
        {
            return null;
        }
        return employee;
    }

    public Employee UpdateEmp(int id, UpdateEmpDto updateEmpDto)
    {
        var employee = appDbContext.Employees.Find(id);
        if (employee is null)
        {
            return null;
        }
        employee.Name = updateEmpDto.Name;
        employee.Email = updateEmpDto.Email;
        employee.Phone = updateEmpDto.Phone;
        employee.Salary = updateEmpDto.Salary;

        appDbContext.SaveChanges();
        return employee;
    }
}