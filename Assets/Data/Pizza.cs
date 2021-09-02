using System;
using UnityEngine;

namespace Data
{
    [System.Serializable]
    public class Pizza
    {
    
        public SizeEnum Size;
        
        public bool Topping1;
        public bool Topping2;
        public bool Topping3;

        public bool Cooked = true;

        public bool[] Toppings => new[] {Topping1, Topping2, Topping3};
        
        public enum SizeEnum
        {
            Quarter,
            Half,
            Full
        }
        public enum ToppingEnum
        {
            First,
            Second,
            Third
        }

        public bool GetTopping(ToppingEnum topping) => topping switch
        {
            ToppingEnum.First => Topping1,
            ToppingEnum.Second => Topping2,
            ToppingEnum.Third => Topping3,
            _ => throw new ArgumentOutOfRangeException(nameof(topping), topping, null)
        };
        
        #region Equality
        public static bool operator ==(Pizza order, Pizza other)
        {
            if (order is null) return other is null;
            if (other is null) return false;
        
            return order.Size == other.Size &&
                   order.Topping1 == other.Topping1 &&
                   order.Topping2 == other.Topping2 &&
                   order.Topping3 == other.Topping3;
        }
        public static bool operator !=(Pizza order, Pizza other) => !(order == other);
        public bool Equals(Pizza other) => this == other;
        public override bool Equals(object obj) => obj is Pizza other && Equals(other);
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) Size;
                hashCode = (hashCode * 397) ^ Topping1.GetHashCode();
                hashCode = (hashCode * 397) ^ Topping2.GetHashCode();
                hashCode = (hashCode * 397) ^ Topping3.GetHashCode();
                return hashCode;
            }
        }
        #endregion
    }
}
