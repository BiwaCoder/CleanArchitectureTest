
using VContainer;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System.Linq;

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


    public void InitializeBattle(int i)
    {
        enemyList = battleInitializer.InitializeEnemy(i);
        UnityEngine.Debug.Log($"StartGame 敵を初期化しました: {enemyList.Count}");      
    }

    public void SettingPlayer()
    {
        //プレイヤーの初期化
        playerList = battleInitializer.InitializePlayer();
        //プレイヤーHPの設定
        this.uiPresenter.SetCharcterList(playerList,enemyList);
        
        
        UnityEngine.Debug.Log($"StartGame PlayerCount: {playerList.Count}");
        //マップの、マップの選択
        GameObjectCreator.Instance.CreateDropDown((int i)=>{ 
            UnityEngine.Debug.Log($"OnDropdownValueChanged:{i}"); 
            InitializeBattle(i);
        });

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
        if(IsEnemyDefeated())
        {
            UnityEngine.Debug.Log("敵を倒しているため戦闘をはじめられません。マップを移動してください");
            return;
        }
        
        //TODO 初回の初期化をまとめる
        var playerDialogue = new CharacterDialogue("さぁバトルを始めよう！", "これでどうだ！");
        var enemyDialogue = new CharacterDialogue("お前に私が倒せるかな？", "くらえ！");
                
        //繰り返しバトルを進める
        var iBattleAction = new BattleAction();
        var resultList = iBattleAction.GoNextTurn(playerList[0], enemyList[0], playerDialogue, enemyDialogue);

        //UIに表示
        this.uiPresenter.SetPlayerHealth(resultList);
        this.uiPresenter.SetCharcterList(playerList,enemyList);
    }

    public bool IsEnemyDefeated()
    {
        // 敵が全滅したかどうかの判定
        if(enemyList?.Any() == false ){
            return true;
        }
        else if(enemyList[0].Hp <= 0){
            //TODO ゲーム終了処理
            UnityEngine.Debug.Log("ゲーム終了");
            return true;
        }
        else
        {
            return false;
        }
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