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

            if (i == 0)
            {
                // 1. Голова (индекс 0) поворачивается по заданному углу от контроллера
                BodyParts[i].transform.rotation = Quaternion.Euler(0, 0, angle);
            }
            else
            {
                // 2. Тело вычисляет направление к предыдущему сегменту (i - 1)
                Vector2 direction = segments[i - 1] - segments[i];

                // Защита от ошибки вычисления угла, если сегменты находятся ровно в одной точке (например, при спавне)
                if (direction != Vector2.zero)
                {
                    // 3. Вычисляем угол в градусах
                    float segmentAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    BodyParts[i].transform.rotation = Quaternion.Euler(0, 0, segmentAngle);
                }
            }
        }
        //gameObject.transform.position = segments[0];
        //gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);
        
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