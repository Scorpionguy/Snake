using UnityEngine;

[CreateAssetMenu(fileName = "FoodConfig", menuName = "Scriptable Objects/FoodConfig")]
public class SpawnConfig : ScriptableObject
{
    public float SpawnDelay;
    public int maxAmount;
    
}
