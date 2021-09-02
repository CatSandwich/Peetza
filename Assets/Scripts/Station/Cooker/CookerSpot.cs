using System;
using System.Collections;
using Data;
using UnityEngine;

namespace Station.Cooker
{
    public class CookerSpot : MonoBehaviour
    {
        public CookerStation Station;
        public PizzaRenderer Renderer;
        public bool Occupied;

        public bool TryOccupy(Pizza pizza)
        {
            if (pizza.Size != Pizza.SizeEnum.Quarter) throw new ArgumentException($"{pizza.Size.ToString()} size pizza reached spot.");
            StartCoroutine(_occupy(Station.Levels[Station.Level].QuarterSpeed, pizza));
            return true;
        }
        
        private IEnumerator _occupy(float time, Pizza pizzaVisual)
        {
            Occupied = true;
            Renderer.Refresh(pizzaVisual);
            yield return new WaitForSeconds(time);
            Occupied = false;
            Renderer.Refresh(null);
        }
    }
}
