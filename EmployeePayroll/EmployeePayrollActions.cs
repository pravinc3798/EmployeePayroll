using System.Data.SqlClient;

namespace EmployeePayroll
{
    public class EmployeePayrollActions
    {
        private static string ConnectionString = "server = DESKTOP-AG70M3D; initial catalog = dbPayrollService; trusted_connection = true";
        private static SqlConnection CreateConnection = null;
        private static SqlTransaction TransactionCommand = null;

        public static void AddEmployee(EmployeePayrollFields employee)
        {
            CreateConnection = new SqlConnection(ConnectionString);
            CreateConnection.Open();

            SqlCommand storedProcedure = new SqlCommand("AddEmployee", CreateConnection);
            storedProcedure.CommandType = System.Data.CommandType.StoredProcedure;

            storedProcedure.Parameters.AddWithValue("@name", employee.EmployeeName);
            storedProcedure.Parameters.AddWithValue("@basicpay", employee.BasicPay);
            storedProcedure.Parameters.AddWithValue("@startdate", employee.StartDate);
            storedProcedure.Parameters.AddWithValue("@gender", employee.Gender);
            storedProcedure.Parameters.AddWithValue("@contact", employee.Contact);
            storedProcedure.Parameters.AddWithValue("@city", employee.City);
            storedProcedure.Parameters.AddWithValue("@state", employee.States);
            storedProcedure.Parameters.AddWithValue("@zip", employee.Zip);
            storedProcedure.Parameters.AddWithValue("@deductions", employee.Deductions);
            storedProcedure.Parameters.AddWithValue("@taxpercent", employee.TaxPercent);

            storedProcedure.ExecuteNonQuery();
        }

    }
}