using VContainer;
using VContainer.Unity;
using UnityEngine;

public class SnakeLifetimeScope : LifetimeScope
{
    [SerializeField] private CharacterController _charracterController;
    [SerializeField] private SnakeView _snakeView;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private SnakeConfig _snakeConfig;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<SnakeModel>(Lifetime.Singleton).WithParameter(_snakeConfig);
        builder.Register<InputProvider>(Lifetime.Singleton)
            .As<IInputProvider>();
        builder.RegisterEntryPoint<SnakeController>(Lifetime.Singleton);

        builder.RegisterComponent(_snakeView);
        builder.RegisterComponent(_charracterController);
        //builder.RegisterComponent(_playerMovement);
    }
}
