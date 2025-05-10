namespace User
{
    public class Client : User
    {
        public Client(string clientName, string clientAddress, string clientPhone)
        {
            UserFullName = clientName;
            UserAddress = clientAddress;
            UserPhone = clientPhone;
            UserType = UserType.Client;
        }
    }
}
