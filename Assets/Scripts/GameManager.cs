using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using Data.Assets;
using Data.Levels;
using Data.Toppings;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Assets Assets;

    public PizzaRenderer InventoryRenderer;

    public Topping Topping1 => Assets.Toppings[0];
    public Topping Topping2 => Assets.Toppings[1];
    public Topping Topping3 => Assets.Toppings[2];

    public Pizza HeldPizza
    {
        get => _heldPizza;
        set => InventoryRenderer.Refresh(_heldPizza = value);
    }
    private Pizza _heldPizza;
    
    void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }

    void PlayLevel(Level level)
    {
        
    }
}
