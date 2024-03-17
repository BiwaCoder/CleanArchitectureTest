using System.Collections;
using System.Diagnostics;
using NUnit.Framework;
using UnityEngine.TestTools;
using VContainer;

public class EditorModeExample
{
    [Test]
    public void ExampleTest()
    {
        var builder = new ContainerBuilder();
        PlayerStatusView playerStanusView = new PlayerStatusView();
        EnemyStatusView enemyStatusView = new EnemyStatusView();
        TurnBattleView turnBattleView = new TurnBattleView();
        
        builder.Register<IBattleController,BattleController>(Lifetime.Singleton);   
        builder.Register<ITurnBasedBattleInputPort, TurnBasedBattleInteractor>(Lifetime.Singleton); 
        builder.Register<IBattleActionInterface, BattleAction>(Lifetime.Singleton);
        builder.Register<ICharacterFactory, CharcterFactoryImpl>(Lifetime.Singleton);
        builder.Register<IDropDownPresenter, DropDownPresenter>(Lifetime.Singleton);
        builder.Register<ITurnBattleOutputPort,DummyPresenter>(Lifetime.Singleton);

        var container = builder.Build();
        var battleController = container.Resolve<IBattleController>();
        battleController.GameInitialize();
        battleController.SelectMap(0);
        battleController.HandleAttackPressed();
       

    }


    


}