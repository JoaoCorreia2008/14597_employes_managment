namespace _14597_employes_managment.Models
{
    public class Employee : UserActivity
    {
        public int Id { get; set; }
        public string EmpNo{ get; set; }

        public string FristName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FristName} {MiddleName} {LastName}";
        public int PhoneNumber { get; set; }
        public string EmailAdress { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }





    }
}
