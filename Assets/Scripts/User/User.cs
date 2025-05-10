namespace User
{
    public abstract class User
    {
        protected int UserId;
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
