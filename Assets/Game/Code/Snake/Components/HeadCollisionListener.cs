using System;
using UnityEngine;

public class HeadCollisionListener : MonoBehaviour
{
    public event Action<FoodItem> onPickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HELLLLLLLLLLLLLLLL YEAAAAAAAAAAAAAAAAAAH");
        if (!collision.gameObject.TryGetComponent(out Food food)) return;

        onPickup?.Invoke(food.GetFoodItem());
        if (onPickup != null)
        Destroy(collision.gameObject);
    }
}
