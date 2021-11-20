namespace NorthWind.Sales.Entities.POCOs
{
#nullable disable
    public class Order
    {
        public int Id { get; init; }
        public string CustomerId { get; init; }
        public string ShipAddress { get; init; }
        public string ShipCity { get; init; }
        public string ShipCountry { get; init; }
        public string ShipPostalCode { get; init; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DiscountType DiscountType { get; init; } = DiscountType.Percentage;
        public double Discount { get; init; } = 10;
        public ShippingType ShippingType { get; init; } = ShippingType.Road;
    }

}
