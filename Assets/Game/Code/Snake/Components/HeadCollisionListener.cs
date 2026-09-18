using System;
using UnityEngine;

public class HeadCollisionListener : MonoBehaviour
{
    public event Action<Food> onPickup;

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("HELLLLLLLLLLLLLLLL YEAAAAAAAAAAAAAAAAAAH");
    //    if (!collision.gameObject.TryGetComponent(out Food food)) return;

    //    onPickup.Invoke(food);
    //}
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HELLLLLLLLLLLLLLLL YEAAAAAAAAAAAAAAAAAAH");
        if (!collision.gameObject.TryGetComponent(out Food food)) return;

        onPickup?.Invoke(food);
        if (onPickup != null)
        Destroy(collision.gameObject);
    }
}
