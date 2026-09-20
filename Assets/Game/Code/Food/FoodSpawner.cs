using System.Linq;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class FoodSpawner : MonoBehaviour
{
    private FoodDatabase _foodDB;
    private IObjectResolver _objectResolver;
    //

    [Inject] public void Construct(FoodDatabase foodDatabase,
        IObjectResolver objectResolver)
    {
        _foodDB = foodDatabase;
        _objectResolver = objectResolver;
    }
    private void Start()
    {
        var ranX = Random.Range(-8, 8);
        var ranY = Random.Range(-8, 8);

        Spawn(new Vector2(ranX, ranY), 1);
    }
    public void Spawn(Vector2 position, short id)
    {
        FoodItem foodItem = _foodDB.FoodsDatabase[id];


        GameObject foodObject = _objectResolver.Instantiate(foodItem.Prefab);
        foodObject.transform.position = position;
        
        Food food = foodObject.GetComponent<Food>();
        food.SetFoodItem(foodItem);

    }
}
