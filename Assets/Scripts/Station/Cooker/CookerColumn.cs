using System;
using System.Collections;
using Data;
using UnityEngine;

namespace Station.Cooker
{
    public class CookerColumn : MonoBehaviour
    {
        public CookerStation Station;
        public PizzaRenderer Renderer;
        public CookerSpot Spot1;
        public CookerSpot Spot2;

        public Pizza Inventory
        {
            get => _inventory;
            set
            {
                if (value != null && value.Size != Pizza.SizeEnum.Half)
                    throw new InvalidOperationException("Adding a not half sized pizza to an oven column.");
                Renderer.Refresh(_inventory = value);
            }
        }
        private Pizza _inventory;
        
        public bool Empty => Inventory == null && !Spot1.Occupied && !Spot2.Occupied;

        public bool TryOccupy(Pizza pizza)
        {
            switch (pizza.Size)
            {
                case Pizza.SizeEnum.Half:
                {
                    if (!Empty) return false;
                    StartCoroutine(_occupy(Station.Levels[Station.Level].HalfSpeed, pizza));
                    return true;
                }
                case Pizza.SizeEnum.Quarter: return Spot1.TryOccupy(pizza) || Spot2.TryOccupy(pizza);
            }

            throw new ArgumentException($"{pizza.Size.ToString()} size pizza reached column.");
        }
        
        private IEnumerator _occupy(float time, Pizza pizzaVisual)
        {
            Spot1.Occupied = Spot2.Occupied = true;
            Renderer.Refresh(pizzaVisual);
            yield return new WaitForSeconds(time);
            Spot1.Occupied = Spot2.Occupied = false;
            Renderer.Refresh(null);
        }
    }
}
