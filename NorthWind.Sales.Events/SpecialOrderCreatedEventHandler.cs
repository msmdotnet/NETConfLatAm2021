using NorthWind.Entities.Events;
using NorthWind.Entities.Interfaces;

namespace NorthWind.Sales.Events;

public class SpecialOrderCreatedEventHandler :
    IEventHandler<SpecialOrderCreatedEvent>
{
    readonly IMailService Sender;

    public SpecialOrderCreatedEventHandler(IMailService sender)
    {
        Sender = sender;
    }

    public ValueTask Handle(SpecialOrderCreatedEvent orderCreated)
    {
        return Sender.Send(
            $"Orden {orderCreated.OrderId} con {orderCreated.ProductsCount} productos.");
    }
}
