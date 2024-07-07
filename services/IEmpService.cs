using Api_2._0;

namespace Api_2;
public interface IEmpService{
    IEnumerable<Employee> GetAllEmp();
    Employee GetEmpById(int id);
    Employee AddEmp(AddEmpDto addEmpDto);
    Employee UpdateEmp(int id, UpdateEmpDto updateEmpDto);
    Boolean DeleteEmp(int id);
}