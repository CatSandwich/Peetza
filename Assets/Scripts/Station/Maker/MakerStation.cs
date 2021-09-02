using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;

namespace Station.Maker
{
    public class MakerStation : Station<MakerStationLevel>
    {
        public PizzaRenderer PizzaRenderer;
        public LoadingBar LoadingBar;

        public Pizza Inventory
        {
            get => _inventory;
            set => PizzaRenderer.Refresh(_inventory = value);
        }
        private Pizza _inventory = null;
        
        [NonSerialized] public bool Busy = false;
    
        private void OnMouseDown()
        {
            if (Busy) return;
            
            if (Inventory == null && Manager.HeldPizza != null)
            {
                Inventory = Manager.HeldPizza;
                Manager.HeldPizza = null;
            }
            else if (Inventory != null && Manager.HeldPizza == null)
            {
                Manager.HeldPizza = Inventory;
                Inventory = null;
            }
        }

        public void MakePizza(Pizza.SizeEnum size)
        {
            if (Busy || Inventory != null) return;
            StartCoroutine(_makePizzaCoroutine(size));
        }

        private IEnumerator _makePizzaCoroutine(Pizza.SizeEnum size)
        {
            Busy = true;
            
            var start = Time.time;
            var speed = Levels[Level].GetSpeed(size);
            
            while (Time.time - start < speed)
            {
                LoadingBar.Value = (Time.time - start) / speed;
                yield return null;
            }

            LoadingBar.Value = 0f;
            Inventory = new Pizza {Size = size, Cooked = false};
            Busy = false;
        }
    }

    [Serializable]
    public class MakerStationLevel : StationLevel
    {
        public int Cost;
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
