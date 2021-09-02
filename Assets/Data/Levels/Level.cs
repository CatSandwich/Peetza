using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Levels
{
    [CreateAssetMenu]
    public class Level : ScriptableObject
    {
        public List<Customer> Customers;
    }

    [Serializable]
    public class Customer
    {
        public Sprite Sprite;
        public Pizza Order;
    }
}
