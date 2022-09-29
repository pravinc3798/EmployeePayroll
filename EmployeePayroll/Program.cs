namespace EmployeePayroll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeePayrollFields employee = new EmployeePayrollFields("mno", 57.15, DateTime.Now, 'M', "1425367489", "Bhopal", "M.P", "104125", 1.35, 0.04);
            //EmployeePayrollActions.AddEmployee(employee);


            EmployeePayrollActions.DeleteEmployeeCascade("Def");
            EmployeePayrollActions.ViewEmployees();
        }
    }
}