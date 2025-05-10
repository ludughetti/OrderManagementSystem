namespace User.Clients
{
    public class Client : User
    {
        private bool _isMember;
        
        public Client(string clientName, string clientAddress, string clientPhone, bool isMember)
        {
            UserFullName = clientName;
            UserAddress = clientAddress;
            UserPhone = clientPhone;
            UserType = UserType.Client;
            _isMember = isMember;
        }

        public bool IsMember()
        {
            return _isMember;
        }
    }
}
