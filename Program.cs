#pragma warning disable CA1050 // Declare types in namespaces
using clean_code_samples.Functions;

public class Program
{
    public readonly IEmployeeService _employeeService;

    public Program(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    public static void Main(string[] args)
    {
        var program = new Program(new EmployeeService()); // DI
        var employeeRecord = new EmployeeRecord { Name = "Lucas", Type = EmployeeTypeEnum.HOURLY };
        var employee = program._employeeService.MakeEmployee(employeeRecord);
        var payment = employee.CalculatePay();
        Console.WriteLine($"Payment for employee {employee} is ${payment}");
    }
}