using UnityEngine;
using VContainer;

public class PlayerMovement : MonoBehaviour
{
    [Inject] private IInputProvider _inputProvider;
    [Inject] private CharacterController _characterController;

    [SerializeField] private float speed;
   

    void Update()
    {
        var input = _inputProvider.GetDirection();

        Vector2 moveDir = new Vector2(1, 1);
        var velocity = moveDir * speed * Time.deltaTime;
        _characterController.Move(velocity);
    }
}
