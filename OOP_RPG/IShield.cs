﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public interface IShield : IShopItem
    {
        int Defense { get; }
    }
}
