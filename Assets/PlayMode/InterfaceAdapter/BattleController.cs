//入力をさばく
using VContainer;

public class BattleController : IBattleController
{
    public readonly IBattleInputPort _inputPort;
    
    [Inject]
    public BattleController(IBattleInputPort inputPort)
    {
        _inputPort = inputPort;
    }

    //この辺で入力を受け取っても良い
    //AutoBattleControllerでやってる読み込みや低レベルの処理を、インタラクターに受け渡す

    public void StartBattle(Character player, Character enemy,CharacterDialogue playerDialogue,CharacterDialogue enemyDialogue)
    {

        _inputPort.HandleBattle(player, enemy, playerDialogue, enemyDialogue);
    }


}
