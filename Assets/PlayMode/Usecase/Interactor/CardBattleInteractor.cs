using UnityEngine;
public class CardBattleInteractor : IBattleSystem, ICardBattleInputPort
{
    public bool IsFirstTurn()
    {
        // 初回ターンかどうかの判定
        return false;
    }

    public void SettingPlayer()
    {
        // ゲーム開始のロジック
    }
    // ゲームの状態やデータを管理するためのフィールド

    public void InitializeBattle(int i)
    {
        // ゲーム初期化のロジック
    }

    public void ExecuteTurn()
    {
        // ターン実行のロジック
    }

    public void UpdateGameStatus()
    {
        // ゲームステータスの更新
    }

    public void EndTurn()
    {
        // ターン終了のロジック
    }

    public bool CheckGameEnd()
    {
        // ゲーム終了条件のチェック
        return false;
    }

    // CardBattleInputPort のメソッド実装

    public void SelectCard(Card card)
    {
        // カード選択の処理
    }

    public void PlayCard(Card card)
    {
        // カードプレイの処理
    }

    public void ManageDeck(DeckAction action)
    {
        // デッキ管理の処理
    }

    public void HandleBattle(Character player, Character enemy, CharacterDialogue playerDialogue, CharacterDialogue enemyDialogue)
    {
        // バトルの処理
    }

    public void SetView(TurnBattleView view)
    {
        // Viewの設定
    }
 
    public void SetParentObject(GameObject parent)
    {
        // Viewの設定
    }
}
