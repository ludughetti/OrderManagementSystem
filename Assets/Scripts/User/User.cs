namespace User
{
    public abstract class User
    {
        public int UserId { get; private set; }
        protected string UserFullName;
        protected string UserPhone;
        protected string UserAddress;
        protected UserType UserType;

        public void SetUserId(int userId)
        {
            UserId = userId;
        }
    }
}
