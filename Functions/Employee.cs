namespace clean_code_samples.Functions
{
    public abstract class Employee
    {
        public string Name { get; set; }
        public EmployeeTypeEnum Type { get; set; }

        public Employee(string name, EmployeeTypeEnum type)
        {
            Name = name;
            Type = type;
        }

        public abstract bool IsPayDay();
        public abstract decimal CalculatePay();
        public abstract void DeliverPay();

        public override string ToString()
        {
            return $"{Name} - {Type}";
        }
    }

    public class CommissionedEmployee : Employee
    {
        public CommissionedEmployee(EmployeeRecord r) : base(r.Name, r.Type)
        { }

        public override decimal CalculatePay()
        {
            return 10;
        }

        public override void DeliverPay()
        {
            Console.WriteLine(Name);
        }

        public override bool IsPayDay()
        {
            return true;
        }
    }

    public class HourlyEmployee : Employee
    {
        public HourlyEmployee(EmployeeRecord r) : base(r.Name, r.Type)
        { }

        public override decimal CalculatePay()
        {
            return 20;
        }

        public override void DeliverPay()
        {
            Console.WriteLine(Name);
        }

        public override bool IsPayDay()
        {
            return false;
        }
    }

    public class SalariedEmployee : Employee
    {
        public SalariedEmployee(EmployeeRecord r) : base(r.Name, r.Type)
        { }
        public override decimal CalculatePay()
        {
            return 30;
        }

        public override void DeliverPay()
        {
            Console.WriteLine(Name);
        }

        public override bool IsPayDay()
        {
            return true;
        }
    }

    public enum EmployeeTypeEnum
    {
        COMMISSIONED,
        HOURLY,
        SALARIED
    }

    public record EmployeeRecord
    {
        public string Name { get; set; }
        public EmployeeTypeEnum Type { get; set; }
    }

    public interface IEmployeeService
    {
        public Employee MakeEmployee(EmployeeRecord r);
    }

    public class EmployeeService : IEmployeeService
    {
        public Employee MakeEmployee(EmployeeRecord r)
        {
            return r.Type switch
            {
                EmployeeTypeEnum.COMMISSIONED => new CommissionedEmployee(r),
                EmployeeTypeEnum.HOURLY => new HourlyEmployee(r),
                EmployeeTypeEnum.SALARIED => new SalariedEmployee(r),
                _ => throw new InvalidEmployeeExcpetion(r.Type),
            };
        }
    }

    internal class InvalidEmployeeExcpetion : Exception
    {
        public InvalidEmployeeExcpetion(EmployeeTypeEnum type)
        {

        }

    }
}