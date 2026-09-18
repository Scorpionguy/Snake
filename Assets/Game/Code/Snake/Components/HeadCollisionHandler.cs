using System;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class HeadCollisionHandler : IStartable, IDisposable
{
    private HeadCollisionListener _headCollisionListener;
    private SnakeController _snakeController;
    [Inject] public HeadCollisionHandler(
        HeadCollisionListener headCollisionListener,
        SnakeController snakeController)
    {
        _headCollisionListener = headCollisionListener;
        _snakeController = snakeController;
    }

    public void Dispose()
    {
        _headCollisionListener.onPickup -= EatFood;
    }

    public void Start()
    {
        _headCollisionListener.onPickup += EatFood;
    }

    private void EatFood(Food food)
    {
        _snakeController.Eat(food);

        Debug.Log("Invoked epta");
    }
}
