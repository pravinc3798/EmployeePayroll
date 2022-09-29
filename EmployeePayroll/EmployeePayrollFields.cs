namespace EmployeePayroll
{
    public class EmployeePayrollFields
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public float BasicPay { get; set; }
        public DateTime StartDate { get; set; }
        public char Gender { get; set; }
        public string Contact { get; set; }
        public string City { get; set; }
        public string States { get; set; }
        public string Zip { get; set; }
        public float Deductions { get; set; }
        public float TaxPercent { get; set; }

        public EmployeePayrollFields(string employeeName, float basicPay, DateTime startDate, char gender, string contact, string city, string states, string zip, float deductions, float taxPercent)
        {
            EmployeeName = employeeName;
            BasicPay = basicPay;
            StartDate = startDate;
            Gender = gender;
            Contact = contact;
            City = city;
            States = states;
            Zip = zip;
            Deductions = deductions;
            TaxPercent = taxPercent;
        }
    }
}