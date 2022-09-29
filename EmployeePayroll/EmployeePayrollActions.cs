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

            CreateConnection.Close();
        }
        
        public static void ViewEmployees()
        {
            CreateConnection = new SqlConnection(ConnectionString);
            CreateConnection.Open();

            SqlCommand storedProcedure = new SqlCommand("GetCompleteDetails", CreateConnection);
            storedProcedure.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader queryData = storedProcedure.ExecuteReader();

            if (queryData.HasRows)
            {
                do
                {
                    if (queryData.Read())
                        Console.WriteLine("ID : {0}, Gender : {1}, Name : {2}, Number : {3}, City : {4}, State : {5}, Zip : {6}, Salary : {7}, StartDate : {8}, Deductions : {9}, Taxpercent : {10}, TaxPaid: {11}, NetPay : {12} \n -----xxxx---- \n",
                            queryData.GetInt32(0), queryData.GetString(1), queryData.GetString(2), queryData.GetString(3), queryData.GetString(4), queryData.GetString(5), queryData.GetString(6), queryData.GetDouble(7), queryData.GetDateTime(8).ToShortDateString(), queryData.GetDouble(9), queryData.GetDouble(10), queryData.GetDouble(11), queryData.GetDouble(12));
                }
                while (queryData.NextResult());
            }

            CreateConnection.Close();
        }
        

    }
}