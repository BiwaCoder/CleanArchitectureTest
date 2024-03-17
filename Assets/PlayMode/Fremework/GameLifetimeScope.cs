using VContainer;
using VContainer.Unity;
using UnityEngine;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private TurnBattleView turnBattleView;

    public GameObject testMonoBehaviour;

    public EnemyStatusView enemyStatusView;
    public PlayerStatusView playerStatusView;



    protected override void Configure(IContainerBuilder builder)
    {
        Debug.Log("GameLifetimeScope");
        builder.Register<IBattleController,BattleController>(Lifetime.Singleton);
        
        builder.Register<ITurnBasedBattleInputPort, TurnBasedBattleInteractor>(Lifetime.Singleton); 
        builder.Register<IBattleActionInterface, BattleAction>(Lifetime.Singleton);
        builder.Register<ICharacterFactory, CharcterFactoryImpl>(Lifetime.Singleton);
        builder.Register<IDropDownPresenter, DropDownPresenter>(Lifetime.Singleton);
        builder.Register<IStatusPresenter, StatusViewPresentor>(Lifetime.Singleton).WithParameter("playerStatusView", playerStatusView).WithParameter("enemyStatusView", enemyStatusView);

        builder.Register<ITurnBattleOutputPort,TurnBattleUIPresenter>(Lifetime.Singleton).WithParameter("view", turnBattleView).WithParameter("model", new TurnBattleModel());
    }
}
