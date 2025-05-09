namespace UI.Orders
{
    public class AddAddOnMenu : OrderMenu
    {
        protected override void LoadScreenData()
        {
            var itemAddOns = orderManager.GetAvailableAddOns();
            
            foreach (var addOnCardData in itemAddOns)
                CreateCard(addOnCardData, orderManager.AddNewAddOn);
        }
    }
}
