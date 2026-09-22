using System;
using UnityEngine;

public class Food : MonoBehaviour
{
    private FoodItem _foodItem;
    public event Action<Food> FoodEated;

    public FoodItem GetFoodItem()
    {
        return _foodItem;
    }
    public void SetFoodItem(FoodItem foodItem)
    {
        _foodItem = foodItem;
    }
    private void OnDestroy()
    {
        FoodEated.Invoke(this);
    }
}
