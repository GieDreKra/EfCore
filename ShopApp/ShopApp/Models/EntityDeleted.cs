﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Models
{
    public class EntityDeleted: EntityName
    {
        public bool isDeleted { get; set; } = false;
    }
}
