public interface IBattleSystem
{

    bool IsFirstTurn();
    void SettingPlayer();
    void InitializeBattle(int i);
    void ExecuteTurn();
    void UpdateGameStatus();
    void EndTurn();
    bool CheckGameEnd();
}