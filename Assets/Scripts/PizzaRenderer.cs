using Data;
using Data.Toppings;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PizzaRenderer : MonoBehaviour
{
    private static GameManager Manager => GameManager.Instance;
    private static Topping Topping1Sprite => Manager.Topping1;
    private static Topping Topping2Sprite => Manager.Topping2;
    private static Topping Topping3Sprite => Manager.Topping3;
    
    public SpriteRenderer Pizza;
    public SpriteRenderer Topping1;
    public SpriteRenderer Topping2;
    public SpriteRenderer Topping3;
    
    public void Start()
    {
        if (!Pizza) Pizza = new GameObject(nameof(Pizza)).AddComponent<SpriteRenderer>();
        if (!Topping1) Topping1 = new GameObject(nameof(Topping1)).AddComponent<SpriteRenderer>();
        if (!Topping2) Topping2 = new GameObject(nameof(Topping2)).AddComponent<SpriteRenderer>();
        if (!Topping3) Topping3 = new GameObject(nameof(Topping3)).AddComponent<SpriteRenderer>();
        
        Pizza.transform.SetParent(transform, false);
        Topping1.transform.SetParent(transform, false);
        Topping2.transform.SetParent(transform, false);
        Topping3.transform.SetParent(transform, false);

        Refresh(null);
    }
    
    public void Refresh(Pizza pizza)
    {
        if (pizza == null)
        {
            Pizza.enabled = Topping1.enabled = Topping2.enabled = Topping3.enabled = false;
            return;
        }
        
        Pizza.enabled = true;
        Pizza.sprite = Manager.Assets.PizzaSprites.GetSprite(pizza.Cooked, pizza.Size);
        
        Topping1.enabled = pizza.Topping1;
        Topping1.sprite = Topping1Sprite.GetSprite(pizza.Size);
        
        Topping2.enabled = pizza.Topping2;
        Topping2.sprite = Topping2Sprite.GetSprite(pizza.Size);

        Topping3.enabled = pizza.Topping3;
        Topping3.sprite = Topping3Sprite.GetSprite(pizza.Size);
    }
}