namespace NorthWind.Sales.ViewModels
{
    public class CreateOrderViewModel
    {
        public int OrderId { get; set; }

        public CreateOrderViewModel(int orderId)
        {
            OrderId = orderId;
        }
    }
}