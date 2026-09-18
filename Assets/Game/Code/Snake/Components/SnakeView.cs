using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using VContainer;

public class SnakeView : MonoBehaviour
{
    [SerializeField] private GameObject _body;
    [SerializeField] private GameObject _head;

    //private SnakeModel _model;

    private List<GameObject> BodyParts = new List<GameObject>();
    public int SnakeViewParts => BodyParts.Count;
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
        BodyParts.Add(_head);   
        
    }
    public void Grow(int diff)
    {
        //BodyParts.Add(Instantiate(_body));
        //BodyParts[BodyParts.Count - 1].transform.position = segment;  
            for (int i = 0; i < diff; i++)
            {
            BodyParts.Add(Instantiate(_body, gameObject.transform));
            }
        }
}