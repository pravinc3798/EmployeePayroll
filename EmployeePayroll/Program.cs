namespace EmployeePayroll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<EmployeePayrollFields> employees1 = new List<EmployeePayrollFields>() { new EmployeePayrollFields("mno", 57.15, DateTime.Now, 'M', "1425367489", "Bhopal", "M.P", "104125", 1.35, 0.04),
            new EmployeePayrollFields("pno", 57.15, DateTime.Now, 'M', "1425367489", "Bhopal", "M.P", "104125", 1.35, 0.04),
            new EmployeePayrollFields("eno", 57.15, DateTime.Now, 'M', "1425367489", "Bhopal", "M.P", "104125", 1.35, 0.04),
            new EmployeePayrollFields("nno", 57.15, DateTime.Now, 'M', "1425367489", "Bhopal", "M.P", "104125", 1.35, 0.04)};

            List<EmployeePayrollFields> employees2 = new List<EmployeePayrollFields>() { new EmployeePayrollFields("ano", 57.15, DateTime.Now, 'M', "1425367489", "Bhopal", "M.P", "104125", 1.35, 0.04),
            new EmployeePayrollFields("bno", 57.15, DateTime.Now, 'M', "1425367489", "Bhopal", "M.P", "104125", 1.35, 0.04),
            new EmployeePayrollFields("cno", 57.15, DateTime.Now, 'M', "1425367489", "Bhopal", "M.P", "104125", 1.35, 0.04),
            new EmployeePayrollFields("dno", 57.15, DateTime.Now, 'M', "1425367489", "Bhopal", "M.P", "104125", 1.35, 0.04)};

            EmployeePayrollActions.AddMultipleEmployees(employees1);
            EmployeePayrollActions.AddMultipleEmployeesUsingThreads(employees2);

            //Result Without Threads - 00:00:00.1954960
            //Result With Threads - 00:00:00.0004523
        }
    }
}