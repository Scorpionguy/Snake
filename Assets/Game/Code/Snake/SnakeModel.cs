using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SnakeModel
{
    public event Action<SnakeModel> OnFoodEaten;
    public List<Vector2> Segments {  get; private set; }    
    
    public float CurrentAngle { get; private set; }
    public float Speed { get; private set; }
    public float TurnSpeed { get; private set; }
    public float Spacing { get; private set; }

    public SnakeModel(SnakeConfig snakeConfig)
    {
        Segments = new List<Vector2> { snakeConfig.initialPosition };
        CurrentAngle = snakeConfig.initialAngle;
        Speed = snakeConfig.initialSpeed;
        TurnSpeed = snakeConfig.turnSpeed;
        Spacing = snakeConfig.spacing;
    }

    public void MoveForward(float steerInput, float deltaTime)
    {
        CurrentAngle -= steerInput * TurnSpeed * deltaTime;
        float radAngle = Mathf.Deg2Rad * CurrentAngle;
        Vector2 direction = new Vector2(Mathf.Cos(radAngle), Mathf.Sin(radAngle));

        Segments[0] += direction * Speed * deltaTime;

        for (int i = 1; i < Segments.Count; i++)
        {
            Vector2 targetPos = Segments[i - 1];
            Vector2 currentPos = Segments[i];

            Vector2 directionToSegment = targetPos - currentPos;
            float distance = directionToSegment.magnitude;

            if (distance > Spacing)
            {
                Vector2 moveDir = directionToSegment / distance;
                Segments[i] = targetPos - (moveDir * Spacing);
            }
        }
        Debug.Log(Segments[0]);
    }
    public void Born(Vector2 pos)
    {
        if (Segments.Count <= 0)
        {
            Segments.Add(pos);
            return;
        }
        for (int i = Segments.Count - 1; i >= 0; i--)
        {
            Segments[i] = pos;
        }
    }
    public void SetPosition(Vector2 pos)
    {
        for (int i = Segments.Count - 1; i >= 0; i--)
        {
            Segments[i] = pos;
        }
    }
    public void Grow()
    {
        Segments.Add(Segments[Segments.Count - 1]);
    }
}
