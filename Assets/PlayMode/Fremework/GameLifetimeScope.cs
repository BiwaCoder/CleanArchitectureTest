using VContainer;
using VContainer.Unity;
using UnityEngine;

public class GameLifetimeScope : LifetimeScope
{

    // testMonoBehaviourをインスペクタで設定する
    [SerializeField] private AutoBattleController testMonoBehaviour;
    [SerializeField] private TurnBattleView turnBattleView;

    protected override void Configure(IContainerBuilder builder)
    {
        Debug.Log("GameLifetimeScope");
        
        builder.Register<IBattleView,AutoBattleView>(Lifetime.Singleton); 
        builder.Register<IBattleOutputPort,BattlePresenter>(Lifetime.Singleton);


        builder.Register<ITurnBasedBattleInputPort, TurnBasedBattleInteractor>(Lifetime.Singleton);
        
        builder.Register<IBattleSystem, TurnBasedBattleInteractor>(Lifetime.Singleton);
        builder.Register<IBattleController,BattleController>(Lifetime.Singleton);

        builder.Register<TurnBattleUIPresenter>(Lifetime.Singleton).WithParameter("view", turnBattleView);


        // testMonoBehaviourのインスタンスを登録する
        builder.RegisterComponent(testMonoBehaviour);

    }
}
