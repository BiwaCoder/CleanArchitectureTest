public interface IBattleSystem
{

    void HandleBattle(Character player, Character enemy,CharacterDialogue playerDialogue,CharacterDialogue enemyDialogue);

    bool IsFirstTurn();
    void SettingPlayer();
    void InitializeBattle();
    void ExecuteTurn();
    void UpdateGameStatus();
    void EndTurn();
    bool CheckGameEnd();

    public void SetView(TurnBattleView view);
}