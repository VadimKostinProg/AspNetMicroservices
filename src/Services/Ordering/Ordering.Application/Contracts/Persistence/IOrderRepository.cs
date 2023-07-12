using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Contracts.Persistence
{
    /// <summary>
    /// Data access logic tools for Order entity.
    /// </summary>
    public interface IOrderRepository : IRepository<Order>
    {
        /// <summary>
        /// Method for reading all orders of the user.
        /// </summary>
        /// <param name="userName">Name of user to read orders.</param>
        /// <returns>Collection IEnumerable of Order entities .</returns>
        Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
    }
}
