using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private FoodDatabase _foodDatabase;
    [SerializeField] private List<GameObject> spawners = new List<GameObject>();

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(_foodDatabase);


        for (int i = 0; i < spawners.Count; i++)
        {
            builder.RegisterInstance(spawners[i]);
        }
    }
}
