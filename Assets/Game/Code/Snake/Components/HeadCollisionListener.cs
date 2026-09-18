using UnityEngine;

public class HeadCollisionListener : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Food") return;


    }
}
