//入力をさばく
using VContainer;

public class BattleController : IBattleController
{
    public readonly IBattleSystem _iBattleSystem;
    
    
    [Inject]
    public BattleController(IBattleSystem battleSystem)
    {
        _iBattleSystem = battleSystem;
    }

    //この辺で入力を受け取っても良い
    //AutoBattleControllerでやってる読み込みや低レベルの処理を、インタラクターに受け渡す
    public void SetView(TurnBattleView view)
    {
        _iBattleSystem.SetView(view);
    }

    public void Onclick(){

    }

    public void GameInitialize()
    {
        _iBattleSystem.SettingPlayer();
    }

}
