namespace UI.Orders
{
    public class CreateOrderMenu : OrderMenu
    {
        protected override void LoadScreenData()
        {
            var ordersCardData = orderManager.GetAvailableOrders();
            
            foreach (var orderCardData in ordersCardData)
                CreateCard(orderCardData, orderManager.CreateNewOrder);
        }
    }
}
