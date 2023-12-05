using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        //実装をどうつたえるか？
        builder.Register<IBattleView,AutoBattleView>(Lifetime.Singleton); 
    }
}
