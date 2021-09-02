using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;

namespace Station.Cooker
{
    public class CookerInventory : MonoBehaviour
    {
        public CookerStation Station;


        /*public PizzaRenderer Renderer;
        public CookerColumn Column1;
        public CookerColumn Column2;

        public Pizza Inventory
        {
            get => _inventory;
            set
            {
                if (value != null && value.Size != Pizza.SizeEnum.Full)
                    throw new InvalidOperationException("Adding a not full sized pizza to full oven inventory.");
                Renderer.Refresh(_inventory = value);
            }
        }
        private Pizza _inventory;

        private CookerLevel Level => Station.Levels[Station.Level];
        
        public bool Empty => Inventory == null && Column1.Empty && Column2.Empty;

        public bool TryOccupy(Pizza pizza)
        {
            switch (pizza.Size)
            {
                case Pizza.SizeEnum.Full:
                {
                    if (!Empty) return false;
                    StartCoroutine(_occupy(Level.FullSpeed, pizza));
                    return true;
                }
                case Pizza.SizeEnum.Quarter: goto case Pizza.SizeEnum.Half;
                case Pizza.SizeEnum.Half: return Column1.TryOccupy(pizza) || Column2.TryOccupy(pizza);
            }

            throw new ArgumentException($"{pizza.Size.ToString()} size pizza reached inventory.");
        }

        private IEnumerator _occupy(float time, Pizza pizzaVisual)
        {
            Column1.Spot1.Occupied = Column1.Spot2.Occupied = Column2.Spot1.Occupied = Column2.Spot2.Occupied = true;
            Renderer.Refresh(pizzaVisual);
            yield return new WaitForSeconds(time);
            Column1.Spot1.Occupied = Column1.Spot2.Occupied = Column2.Spot1.Occupied = Column2.Spot2.Occupied = false;
            Renderer.Refresh(pizzaVisual);
        }*/
    }
}