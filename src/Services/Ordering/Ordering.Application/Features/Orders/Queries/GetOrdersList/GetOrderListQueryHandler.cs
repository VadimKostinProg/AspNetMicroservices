using AutoMapper;
using MediatR;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrderListQueryHandler : IRequestHandler<GetOrdersListQuery, List<OrderDTO>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderListQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderDTO>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrdersByUserName(request.UserName);

            return _mapper.Map<List<OrderDTO>>(orders);
        }
    }
}
