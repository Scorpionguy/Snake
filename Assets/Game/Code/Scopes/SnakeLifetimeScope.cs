using VContainer;
using VContainer.Unity;
using UnityEngine;

public class SnakeLifetimeScope : LifetimeScope
{
    [SerializeField] private SnakeView _snakeView;
    [SerializeField] private SnakeConfig _snakeConfig;
    [SerializeField] private HeadCollisionListener _headCollisionListener;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(_snakeView);
        builder.Register<SnakeModel>(Lifetime.Singleton).WithParameter(_snakeConfig);
        builder.Register<InputProvider>(Lifetime.Singleton)
            .As<IInputProvider>();
        builder.RegisterEntryPoint<SnakeController>(Lifetime.Singleton)
            .AsSelf();

        builder.RegisterComponent(_headCollisionListener);
        builder.RegisterEntryPoint<HeadCollisionHandler>(Lifetime.Singleton);
    }
}
