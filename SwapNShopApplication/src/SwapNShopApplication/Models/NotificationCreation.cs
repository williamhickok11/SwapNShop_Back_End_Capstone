﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwapNShopApplication.Models
{
    public class NotificationCreation
    {
        public int IdPostingMusician { get; set; }
        public int IdRecievingMusician { get; set; }
        public int description { get; set; }
        public int IdNotification { get; set; }
    }
}
