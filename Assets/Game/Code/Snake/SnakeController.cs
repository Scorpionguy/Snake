using UnityEngine;
using VContainer.Unity;

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
        _model.MoveForward(_inputProvider.GetDirection(), Time.deltaTime);
        _view.Draw(_model.Segments, _model.CurrentAngle);
    }
}
