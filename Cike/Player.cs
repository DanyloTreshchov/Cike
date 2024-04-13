﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cike.CikeEngine;

namespace Cike
{
    public class Player : GameObject
    {
        public Player() : base(new Transform(new Vector2D(100, 100)), new Sprite2D())
        {
            scripts.Add(new PlayerScript());
        }
    }
}
