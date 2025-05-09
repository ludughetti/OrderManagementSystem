using Order;

namespace UI.Orders
{
    public class AddItemMenu : OrderMenu
    {
        protected override void LoadScreenData()
        {
            var orderItems = orderManager.GetAvailableOrderItems();
            
            foreach (var itemCardData in orderItems)
                CreateCard(itemCardData, orderManager.AddNewItem);
        }
    }
}
