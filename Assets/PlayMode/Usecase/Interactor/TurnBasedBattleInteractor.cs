
using VContainer;
using System.Collections.Generic;
using System.Diagnostics;

public class TurnBasedBattleInteractor : IBattleSystem, ITurnBasedBattleInputPort
{
    public TurnBattleUIPresenter uiPresenter ;

    //TODO これここにいるか？
    BattleInitializer battleInitializer = new BattleInitializer(new PlayerFactory(),new EnemyFactory());

    // 初回ターンかどうかのフラグ
    bool IsFirstTurnFlag = true;

    //プレイヤーキャラクターのリスト
    public List<Character> playerList = new List<Character>();
    //エネミーキャラクターのリスト
    public List<Character> enemyList = new List<Character>();

    
    //[Inject]
    //public void InjectSub()
    //{
    public void SetView(TurnBattleView turnBattleView){
        this.uiPresenter = new TurnBattleUIPresenter(turnBattleView,this);
    }


    public void InitializeBattle()
    {
        enemyList = battleInitializer.InitializeEnemy();
        UnityEngine.Debug.Log($"StartGame EnemyCount: {enemyList.Count}");
        // ゲーム初期化のロジック
        // プレイヤーや敵の初期化

      
    }

    public void SettingPlayer()
    {
        playerList = battleInitializer.InitializePlayer();
        UnityEngine.Debug.Log($"StartGame PlayerCount: {playerList.Count}");
        //マップの表示
        GameObjectCreator.Instance.CreateDropDown(this,(int i)=>{ UnityEngine.Debug.Log($"OnDropdownValueChanged:{i}"); });

        //敵を初期化して、UIに表示する
    }

    public void SelectMap(){
        //先頭を開始する

    }


    public bool IsFirstTurn()
    {
        // 初回ターンかどうかの判定
        if(IsFirstTurnFlag){
            IsFirstTurnFlag = false;
            return true;
        }
        else{
            return false;
        }
    }


    public void PerformAction(TurnBattleAction action)
    {
        // プレイヤーのアクションを処理
        
    }


    public void ExecuteTurn()
    {
        if(IsFirstTurn())
        {
            InitializeBattle();
        }
        
        //TODO 初回の初期化をまとめる
        var playerDialogue = new CharacterDialogue("さぁバトルを始めよう！", "これでどうだ！");
        var enemyDialogue = new CharacterDialogue("お前に私が倒せるかな？", "くらえ！");
                
        //繰り返しバトルを進める
        var iBattleAction = new BattleAction();
        var resultList = iBattleAction.GoNextTurn(playerList[0], enemyList[0], playerDialogue, enemyDialogue);


        //敵を倒して状態遷移させる
        //行動を選ぶ

        //UI弐表示
        this.uiPresenter.SetPlayerHealth(resultList);


    }

    public void UpdateGameStatus()
    {
        // ゲームステータスの更新
        // HPや状態異常などの更新
    }


    public bool CheckGameEnd()
    {
        // ゲーム終了条件のチェック（全員のHPが0、時間切れなど）
        return false;
    }

    // TurnBasedBattleInputPort のメソッド実装

    public void EndTurn()
    {
        // ターン終了のロジック
        // 次のプレイヤー/敵のターンへの準備
    }

}