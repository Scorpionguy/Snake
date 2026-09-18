using UnityEngine;
using VContainer;

public class SnakeControllerMB : MonoBehaviour
{
    private IInputProvider _inputProvider;
    private CharacterController _characterController;
    private SnakeModel _snakeModel;
    [SerializeField] private float speed;

    private Vector2 defaultDir = new Vector2(0,0);

    [Inject]
    public void Construct(IInputProvider inputProvider,
        CharacterController characterController,
        SnakeModel model)
    {
        _inputProvider = inputProvider;
        _characterController = characterController;
        _snakeModel = model;
    }

    private void Start()
    {
        _snakeModel.Born(transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        //var input = _inputProvider.GetDirection();
        //if (input == defaultDir)
        //{
        //    _snakeModel.SetDirection(transform.up);
        //}
        //else
        //{
        //    _snakeModel.SetDirection(input);
        //}
        //var velocity = _snakeModel.CurrentDirection * speed * Time.deltaTime;
        //_characterController.Move(velocity);
        //TODO: остановился на спавне змеии и синхронизации модели с визуалом
    }
}
