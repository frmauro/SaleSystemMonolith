﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleSystem.Models
{
    public class EditOrderViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public  string CreateDate { get; set; }
        public  string ChangeDate { get; set; }
        public string CurrentStatus { get; set; }
        public string Status { get; set; }
    }
}
