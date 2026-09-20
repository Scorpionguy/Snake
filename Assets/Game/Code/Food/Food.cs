using UnityEngine;

public class Food : MonoBehaviour
{
    private FoodItem _foodItem;

    public FoodItem GetFoodItem()
    {
        return _foodItem;
    }
    public void SetFoodItem(FoodItem foodItem)
    {
        _foodItem = foodItem;
    }
}
