
using VContainer;

public class TurnBasedBattleInteractor : IBattleSystem, ITurnBasedBattleInputPort
{
    public readonly IBattleOutputPort _outputPort;

    [Inject]
    public TurnBasedBattleInteractor(IBattleOutputPort outputPort)
    {
        _outputPort = outputPort;
    }

    // ゲームの状態やデータを管理するフィールド

    public void InitializeGame()
    {
        // ゲーム初期化のロジック
    }

    public void ExecuteTurn()
    {
        // ターン実行のロジック
        // プレイヤーや敵のアクションを処理する
    }

    public void UpdateGameStatus()
    {
        // ゲームステータスの更新
        // HPや状態異常などの更新
    }

    public void EndTurn()
    {
        // ターン終了のロジック
        // 次のプレイヤー/敵のターンへの準備
    }

    public bool CheckGameEnd()
    {
        // ゲーム終了条件のチェック（全員のHPが0、時間切れなど）
        return false;
    }

    // TurnBasedBattleInputPort のメソッド実装

    public void PerformAction(BattleAction action)
    {
        // プレイヤーのアクションを処理
    }

    public void HandleBattle(Character player, Character enemy,CharacterDialogue playerDialogue,CharacterDialogue enemyDialogue)
    {
        var iBattleAction = new BattleAction();
        var resultList = iBattleAction.GoNextTurn(player, enemy, playerDialogue, enemyDialogue);

        _outputPort.PresentBattleResult(resultList);
    }
}
