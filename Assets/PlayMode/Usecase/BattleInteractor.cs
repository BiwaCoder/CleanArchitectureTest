
using VContainer;

public class BattleInteractor : IBattleInputPort
{
    public readonly IBattleOutputPort _outputPort;

    [Inject]
    public BattleInteractor(IBattleOutputPort outputPort)
    {
        _outputPort = outputPort;
    }

    public void HandleBattle(Character player, Character enemy,CharacterDialogue playerDialogue,CharacterDialogue enemyDialogue)
    {
        var iBattleAction = new BattleAction();
        var resultList = iBattleAction.GoNextTurn(player, enemy, playerDialogue, enemyDialogue);

        _outputPort.PresentBattleResult(resultList);
    }
}