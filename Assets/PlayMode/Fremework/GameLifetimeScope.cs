using VContainer;
using VContainer.Unity;
using UnityEngine;

public class GameLifetimeScope : LifetimeScope
{

    // testMonoBehaviourをインスペクタで設定する
    [SerializeField] private AutoBattleController testMonoBehaviour;

    protected override void Configure(IContainerBuilder builder)
    {
        Debug.Log("GameLifetimeScope");
        builder.Register<IBattleView,AutoBattleView>(Lifetime.Singleton); 
        builder.Register<IBattleOutputPort,BattlePresenter>(Lifetime.Singleton);
        builder.Register<IBattleInputPort,BattleInteractor>(Lifetime.Singleton);
        builder.Register<IBattleController,BattleController>(Lifetime.Singleton);

        // testMonoBehaviourのインスタンスを登録する
        builder.RegisterComponent(testMonoBehaviour);

    }
}
