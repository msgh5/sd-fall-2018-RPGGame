﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public interface IShopItem
    {
        string Name { get; }
        int Price { get; }
        string GetDescription();
    }
}
