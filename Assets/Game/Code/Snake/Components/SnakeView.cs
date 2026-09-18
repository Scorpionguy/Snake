using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using VContainer;
using static UnityEngine.Rendering.HableCurve;

public class SnakeView : MonoBehaviour
{
    [SerializeField] private GameObject _body;
    [SerializeField] private GameObject _head;

    //private SnakeModel _model;

    private List<GameObject> BodyParts = new List<GameObject>();
    public void Draw(List<Vector2> segments, float angle)
    {
        for (int i = 0; i < BodyParts.Count; i++)
        {
            BodyParts[i].transform.position = segments[i];
            BodyParts[i].transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        gameObject.transform.position = segments[0];
        gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    public void CreateSnake(List<Vector2> segments)
    {
        //BodyParts[0] = Instantiate(_head, gameObject.transform);
        BodyParts.Add(Instantiate(_head, gameObject.transform));

            
    }
    private void Grow(Vector2 segment)
    {
        BodyParts.Add(Instantiate(_body));
        BodyParts[BodyParts.Count - 1].transform.position = segment;
    }
}
