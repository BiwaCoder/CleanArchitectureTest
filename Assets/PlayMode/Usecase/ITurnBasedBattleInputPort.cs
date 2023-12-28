public interface ITurnBasedBattleInputPort
{
    void HandleBattle(Character player, Character enemy,CharacterDialogue playerDialogue,CharacterDialogue enemyDialogue);
    void PerformAction(BattleAction action);
    void EndTurn();
}

