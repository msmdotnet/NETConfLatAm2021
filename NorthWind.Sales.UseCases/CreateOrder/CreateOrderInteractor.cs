using NorthWind.Entities.Events;
using NorthWind.Entities.Interfaces;
using NorthWind.Entities.Validators;
using NorthWind.Sales.DTOs.CreateOrder;
using NorthWind.Sales.Entities.Aggregates;
using NorthWind.Sales.Events;
using NorthWind.Sales.UseCases.Common.Interfaces;
using NorthWind.Sales.UseCasesPorts.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.UseCases.CreateOrder
{
    public class CreateOrderInteractor : ICreateOrderInputPort
    {
        readonly IValidatorService<CreateOrderDTO> ValidatorService;
        readonly IEnumerable<IValidator<CreateOrderDTO>> Validators;
        readonly IApplicationStatusLogger Logger;
        readonly IOrderWritableRepository OrderRepository;
        readonly ILogWritableRepository LogRepository;
        readonly IUnitOfWork UnitOfWork;
        readonly IEventHub<SpecialOrderCreatedEvent> EventHub;
        readonly ICreateOrderOutputPort OutputPort;

        public CreateOrderInteractor(IValidatorService<CreateOrderDTO> validatorService, 
            IEnumerable<IValidator<CreateOrderDTO>> validators, 
            IApplicationStatusLogger logger, 
            IOrderWritableRepository orderRepository, 
            ILogWritableRepository logRepository, IUnitOfWork unitOfWork, 
            IEventHub<SpecialOrderCreatedEvent> eventHub, 
            ICreateOrderOutputPort outputPort)
        {
            ValidatorService = validatorService;
            Validators = validators;
            Logger = logger;
            OrderRepository = orderRepository;
            LogRepository = logRepository;
            UnitOfWork = unitOfWork;
            EventHub = eventHub;
            OutputPort = outputPort;
        }

        public async ValueTask Handle(CreateOrderDTO order)
        {
            ValidatorService.Validate(order, Validators, Logger);

            OrderAggregate OrderAggregate = new OrderAggregate
            {
                CustomerId = order.CustomerId,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipCountry = order.ShipCountry,
                ShipPostalCode = order.ShipPostalCode
            };
            foreach(var Item in order.OrderDetails)
            {
                OrderAggregate.AddDetail(Item.ProductId, Item.UnitPrice, Item.Quantity);
            }

            OrderRepository.CreateOrder(OrderAggregate);
            LogRepository.Add("Crear orden de compra");
            await UnitOfWork.SaveChanges();

            if(OrderAggregate.OrderDetails.Count>3)
            {
                await EventHub.Raise(new SpecialOrderCreatedEvent
                    (OrderAggregate.Id, OrderAggregate.OrderDetails.Count));
            }

            await OutputPort.Handle( OrderAggregate.Id);

        }
    }
}
