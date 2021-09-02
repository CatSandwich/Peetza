using System;
using System.Collections.Generic;
using Data;
using UnityEditor.UIElements;
using UnityEngine;

namespace Station.Cooker
{
    public class CookerStation : Station<CookerLevel>
    {
        public PizzaRenderer Renderer;
        public LoadingBar Bar;
        public Pizza Inventory
        {
            get => _inventory;
            set 
            {
                Renderer.Refresh(_inventory = value);
                if (value == null || value.Cooked) return;
                
                // If uncooked, cook it
                SetTimeout(Levels[Level].GetSpeed(value.Size), update: progress => Bar.Value = progress, end: () =>
                {
                    value.Cooked = true;
                    Inventory = value;
                    Bar.Value = 0f;
                });
            }
        }
        private Pizza _inventory;

        private void OnMouseDown()
        {
            if (Manager.HeldPizza != null && Inventory == null)
            {
                Inventory = Manager.HeldPizza;
                Manager.HeldPizza = null;
            }
            
            else if (Inventory != null && Inventory.Cooked && Manager.HeldPizza == null)
            {
                Manager.HeldPizza = Inventory;
                Inventory = null;
            }
        }
    }

    [Serializable]
    public class CookerLevel : StationLevel
    {
        public float QuarterSpeed;
        public float HalfSpeed;
        public float FullSpeed;

        public float GetSpeed(Pizza.SizeEnum size) => size switch
        {
            Pizza.SizeEnum.Quarter => QuarterSpeed,
            Pizza.SizeEnum.Half => HalfSpeed,
            Pizza.SizeEnum.Full => FullSpeed,
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, null)
        };
    }
}
