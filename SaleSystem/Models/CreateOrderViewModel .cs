using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleSystem.Models
{
    public class CreateOrderViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public  string CreateDate { get; set; }
        public  string ChangeDate { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }

        public  List<CreateItemOrderViewModel> Itens { get; set; }

    }
}
