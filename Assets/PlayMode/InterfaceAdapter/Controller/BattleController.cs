using VContainer;


public class BattleController : IBattleController
{
    public ITurnBasedBattleInputPort _iTurnBasedInputPort;
    
    [Inject]
    public BattleController(ITurnBasedBattleInputPort iBattleSystem)
    {
        _iTurnBasedInputPort = iBattleSystem;
    }

    public void GameInitialize()
    {
        _iTurnBasedInputPort.SettingPlayer();
    }

    public void SelectMap(int i)
    {
        _iTurnBasedInputPort.SelectMapAndInitializeEnemy(i);
    }

    public void HandleAttackPressed()
    {
        _iTurnBasedInputPort.ExecuteTurn();
    }

}
