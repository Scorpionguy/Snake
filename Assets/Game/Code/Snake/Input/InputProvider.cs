using UnityEngine;
using UnityEngine.InputSystem;

public class InputProvider : IInputProvider
{
    private InputSystemActions _actions;
    public InputProvider()
    {
        _actions = new InputSystemActions();
        _actions.Player.Enable();
    }
    public float GetDirection()
    {
        return _actions.Player.Move.ReadValue<Vector2>().x;
    }
}
