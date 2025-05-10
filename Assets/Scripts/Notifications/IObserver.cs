namespace Notifications
{
    public interface IObserver
    {
        void Update(Order.Order order);
    }
}
