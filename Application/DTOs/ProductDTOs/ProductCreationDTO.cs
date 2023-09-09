using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Application.DTOs.ProductDTOs
{
    public class ProductCreationDTO

    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Pricing { get; set; }
        public int Availability { get; set; }

        public int UserId { get; set; }
 
    }
}
