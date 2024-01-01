public interface IBattleSystem
{

    bool IsFirstTurn();
    void SettingPlayer();
    void InitializeBattle();
    void ExecuteTurn();
    void UpdateGameStatus();
    void EndTurn();
    bool CheckGameEnd();

    public void SetView(TurnBattleView view);
}