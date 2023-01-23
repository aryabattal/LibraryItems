using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManageLibraryItemsAndEmployees.Data.Entities
{

    public class Order
    {
        public Order(IdentityUser user)
        {
            User = user;
        }

        public Order(string orderId, string userId, DateTime createdAt)
        {
            OrderId = orderId;
            UserId = userId;
            CreatedAt = createdAt;
        }

        public string OrderId { get; protected set; }

        public string UserId { get; protected set; }

        public IdentityUser User { get; protected set; }

        [Required]
        public DateTime CreatedAt { get; protected set; } = DateTime.Now;

        public ICollection<OrderLine> OrderLines { get; set; }
            = new List<OrderLine>();
    }
}