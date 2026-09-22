
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class FoodSpawner : MonoBehaviour
{
    private FoodDatabase _foodDB;
    private IObjectResolver _objectResolver;

    float SpawnDelay;
    float spanTime = 0;
    int maxAmount;
    int currentAmount = 0;

    [Inject] public void Construct(FoodDatabase foodDatabase,
        IObjectResolver objectResolver,
        SpawnConfig spawnConfig)
    {
        _foodDB = foodDatabase;
        _objectResolver = objectResolver;
        SpawnDelay = spawnConfig.SpawnDelay;
        maxAmount = spawnConfig.maxAmount;
    }

    public void Spawn(Vector2 position, short id)
    {
        FoodItem foodItem = _foodDB.FoodsDatabase[id];


        GameObject foodObject = _objectResolver.Instantiate(foodItem.Prefab);
        foodObject.transform.position = position;
        
        Food food = foodObject.GetComponent<Food>();
        food.SetFoodItem(foodItem);
        food.FoodEated += FoodEated;
        currentAmount += 1;
    }

    private void Update()
    {
        spanTime += Time.deltaTime;
        Debug.Log(SpawnDelay - spanTime);
        if (spanTime >= SpawnDelay && maxAmount > currentAmount)
        {
            var ranX = Random.Range(-8, 8);
            var ranY = Random.Range(-8, 8);
            spanTime = 0;
            Spawn(new Vector2(ranX, ranY), 1);
        }
        
    }
    private void FoodEated(Food food)
    {
        currentAmount -= 1;
        food.FoodEated -= FoodEated;
        Debug.Log("Describe " + currentAmount);

    }
}
