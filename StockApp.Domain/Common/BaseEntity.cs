﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }
    }
}
