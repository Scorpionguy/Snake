using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "FoodDatabase", menuName = "Scriptable Objects/FoodDatabase")]
public class FoodDatabase : ScriptableObject
{
    [SerializeField] private List<FoodItem> foods;

    public Dictionary<short, FoodItem> FoodsDatabase { get; private set; }

    private void OnEnable()
    {
        FoodsDatabase = new Dictionary<short, FoodItem>();

        for (short i = 0; i < foods.Count; i++)
        {
            FoodsDatabase.Add(foods[i].Id, foods[i]);
        }
    }
}
