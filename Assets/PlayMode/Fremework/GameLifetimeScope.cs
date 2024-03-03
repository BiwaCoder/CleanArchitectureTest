using VContainer;
using VContainer.Unity;
using UnityEngine;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private TurnBattleView turnBattleView;

    public GameObject testMonoBehaviour;

    public EnemyStatusView enemyStatusView;
    public PlayerStatusView playerStatusView;

    //public Drop


    protected override void Configure(IContainerBuilder builder)
    {
        Debug.Log("GameLifetimeScope");
        builder.Register<IBattleController,BattleController>(Lifetime.Singleton);
        
        builder.Register<ITurnBasedBattleInputPort, TurnBasedBattleInteractor>(Lifetime.Singleton); 
        builder.Register<ICharcterRepository, CharcterRepositoryImp>(Lifetime.Singleton);
        builder.Register<IDropDownPresenter, DropDownPresenter>(Lifetime.Singleton);
        builder.Register<TurnBattleUIPresenter>(Lifetime.Singleton).WithParameter("view", turnBattleView).WithParameter("statusPresenter", new StatusViewPresentor(playerStatusView,enemyStatusView));
        
        //builder.Register<iStatusPresenter, StatusViewPresentor>(Lifetime.Singleton).WithParameter("playerStatusView", playerStatusView).WithParameter("enemyStatusView", enemyStatusView);
        // testMonoBehaviourのインスタンスを登録する
        builder.RegisterComponent(testMonoBehaviour);

    }
}
