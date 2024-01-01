public interface ITurnBasedBattleInputPort
{
    void PerformAction(TurnBattleAction action);
    void EndTurn();
}

