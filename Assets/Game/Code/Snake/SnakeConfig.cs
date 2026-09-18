using UnityEngine;

[CreateAssetMenu(fileName = "SnakeConfig", menuName = "Scriptable Objects/SnakeConfig")]
public class SnakeConfig : ScriptableObject
{
    public Vector2 initialPosition;
    public float initialAngle;
    public float initialSpeed;
    public float turnSpeed;
    public float spacing;
}
