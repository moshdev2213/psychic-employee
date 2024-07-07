namespace Api_2;

public class UpdateEmpDto
{
    public required String Name { get; set; }
    public required String Email { get; set; }
    public String? Phone { get; set; }
    public decimal Salary { get; set; }
}