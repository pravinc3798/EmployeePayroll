namespace EmployeePayroll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeePayrollFields employee = new EmployeePayrollFields("mno", 57.15f, DateTime.Now, 'M', "1425367489", "Bhopal", "M.P", "104125", 1.35f, 0.04f);
            EmployeePayrollActions.AddEmployee(employee);
        }
    }
}