using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using VContainer.Unity;
using static UnityEngine.Rendering.HableCurve;

public class SnakeController : ITickable, IStartable
{
    private SnakeModel _model;
    private SnakeView _view;
    private IInputProvider _inputProvider;
    public SnakeController(SnakeModel snakeModel,
        IInputProvider inputProvider,
        SnakeView snakeView)
    {
        _model = snakeModel;
        _view = snakeView;
        _inputProvider = inputProvider;
    }

    public void Start()
    {
        _view.CreateSnake(_model.Segments);
    }

    public void Tick()
    {
        int diff = _model.Segments.Count - _view.SnakeViewParts;
        if (diff > 0) 
            _view.Grow(diff);
        _model.MoveForward(_inputProvider.GetDirection(), Time.deltaTime);
        _view.Draw(_model.Segments, _model.CurrentAngle);

    }
    public void Eat(Food food)
    {
        _model.Grow(food.Saturation);
    }
}
