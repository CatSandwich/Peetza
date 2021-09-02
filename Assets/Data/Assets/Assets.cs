using System;
using System.Collections.Generic;
using Data.Toppings;
using UnityEngine;

namespace Data.Assets
{
    [CreateAssetMenu]
    public class Assets : ScriptableObject
    {
        public Material DefaultLine;

        public PizzaTree PizzaSprites;
        public Topping[] Toppings;
    }

    [Serializable]
    public class PizzaTree
    {
        public Sprite UncookedFull;
        public Sprite UncookedHalf;
        public Sprite UncookedQuarter;
        public Sprite CookedFull;
        public Sprite CookedHalf;
        public Sprite CookedQuarter;

        public Sprite GetSprite(bool cooked, Pizza.SizeEnum size) => cooked switch
        {
            true => size switch
            {
                Pizza.SizeEnum.Quarter => CookedQuarter,
                Pizza.SizeEnum.Half => CookedHalf,
                Pizza.SizeEnum.Full => CookedFull,
                _ => throw new ArgumentOutOfRangeException(nameof(size), size, null)
            },
            false => size switch
            {
                Pizza.SizeEnum.Quarter => UncookedQuarter,
                Pizza.SizeEnum.Half => UncookedHalf,
                Pizza.SizeEnum.Full => UncookedFull,
                _ => throw new ArgumentOutOfRangeException(nameof(size), size, null)
            }
        };
    }
}
