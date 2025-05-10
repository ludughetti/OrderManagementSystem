namespace User
{
    public class Employee : User
    {
        public Employee(string employeeName, string employeeAddress, string employeePhone)
        {
            UserFullName = employeeName;
            UserAddress = employeeAddress;
            UserPhone = employeePhone;
            UserType = UserType.Employee;
        }
    }
}
