public interface IBattleSystem
{
    void InitializeGame();
    void ExecuteTurn();
    void UpdateGameStatus();
    void EndTurn();
    bool CheckGameEnd();
}