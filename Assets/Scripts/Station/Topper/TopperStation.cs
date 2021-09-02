using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;

namespace Station.Topper
{
    public class TopperStation : Station<TopperStationLevel>
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

        public void TopPizza(Pizza.ToppingEnum topping)
        {
            if (Busy || Inventory == null || Inventory.Cooked || Inventory.GetTopping(topping)) return;
            StartCoroutine(_topPizzaCoroutine(topping));
        }

        private IEnumerator _topPizzaCoroutine(Pizza.ToppingEnum topping)
        {
            Busy = true;
            
            var start = Time.time;
            var speed = Levels[Level].GetSpeed(Inventory.Size);
            
            while (Time.time - start < speed)
            {
                LoadingBar.Value = (Time.time - start) / speed;
                yield return null;
            }

            LoadingBar.Value = 0f;
            var b = topping switch
            {
                Pizza.ToppingEnum.First => Inventory.Topping1 = true,
                Pizza.ToppingEnum.Second => Inventory.Topping2 = true,
                Pizza.ToppingEnum.Third => Inventory.Topping3 = true,
                _ => throw new ArgumentOutOfRangeException(nameof(topping), topping, null)
            };
            PizzaRenderer.Refresh(Inventory);
            
            Busy = false;
        }
        
    }
    
    [Serializable]
    public class TopperStationLevel : StationLevel
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
