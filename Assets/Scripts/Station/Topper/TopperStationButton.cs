using System;
using Data;
using UnityEngine;

namespace Station.Topper
{
    public class TopperStationButton : MonoBehaviour
    {
        public TopperStation Topper;
        public Pizza.ToppingEnum Topping;
        private void OnMouseDown() => Topper.TopPizza(Topping);
    }
}
