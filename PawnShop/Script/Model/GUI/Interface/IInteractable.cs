﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Script.Model.GUI.Interface
{
    public interface IInteractable : IVisible
    {
        public abstract bool Active { get; }

        public abstract void Activate();

        public abstract void Deactivate();

        public abstract void Update();
    }
}