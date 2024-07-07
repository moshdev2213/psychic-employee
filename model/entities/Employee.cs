namespace Api_2._0;

public class Employee
{
    public int Id { get; set; }
    public required String Name { get; set; }
    public required String Email { get; set; }
    public String? Phone { get; set; }
    public decimal Salary { get; set; }
}