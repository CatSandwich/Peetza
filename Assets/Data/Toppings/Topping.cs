using System;
using UnityEngine;

namespace Data.Toppings
{
    [CreateAssetMenu]
    public class Topping : ScriptableObject
    {
        public Sprite Quarter;
        public Sprite Half;
        public Sprite Full;

        public Sprite GetSprite(Pizza.SizeEnum size) => size switch
        {
            Pizza.SizeEnum.Quarter => Quarter,
            Pizza.SizeEnum.Half => Half,
            Pizza.SizeEnum.Full => Full,
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, null)
        };
    }
}
