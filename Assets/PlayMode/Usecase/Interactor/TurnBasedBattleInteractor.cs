
using VContainer;
using System.Collections.Generic;
using System.Linq;
using System;

public class TurnBasedBattleInteractor : ITurnBasedBattleInputPort
{
    public TurnBattleUIPresenter uiPresenter ;
    
    //プレイヤーキャラクターのリスト
    private List<Character> playerList = new List<Character>();
    //エネミーキャラクターのリスト
    private List<Character> enemyList = new List<Character>();
    
    private CharacterDialogue playerDialogue;
    private CharacterDialogue enemyDialogue;

    private ICharcterRepository _charcterRepository;

    [Inject]
    public TurnBasedBattleInteractor(TurnBattleUIPresenter uiPresenter, ICharcterRepository charcterRepository)
    {
        UnityEngine.Debug.Log("TurnBasedBattleInteractor");;
        this.uiPresenter = uiPresenter;
        _charcterRepository = charcterRepository;
    }

    //プレイヤーの初期化
    public void SettingPlayer()
    {
        //プレイヤーの初期化
        playerList = _charcterRepository.InitializePlayer();
        var dialog = _charcterRepository.InitCharcterDialog();
        playerDialogue = dialog.Item1;
        enemyDialogue = dialog.Item2;
   
        //プレイヤーHPの設定
        this.uiPresenter.SetCharcterList(playerList,enemyList);        
        UnityEngine.Debug.Log($"StartGame PlayerCount: {playerList.Count}");
    }

    //敵データの初期化、ドロップダウンの変更似合わせて
    //マップの選択に合わせてデータを反映
    public void SelectMapAndInitializeEnemy(int i)
    {
        enemyList = _charcterRepository.InitializeEnemy(i);
        UnityEngine.Debug.Log($"StartGame 敵を初期化しました: {enemyList.Count}");
        this.uiPresenter.SetCharcterList(playerList,enemyList);              
    }

    //状況が揃っているなら、ターンを進行させる
    public void ExecuteTurn()
    {
        UnityEngine.Debug.Log("ExecuteTurn");
        if(IsEnemyDefeated())
        {
            UnityEngine.Debug.Log("敵を倒しているため戦闘をはじめられません。マップを移動してください");
            return;
        }
        
        //繰り返しバトルを進める
        var iBattleAction = new BattleAction();
        var resultList = iBattleAction.GoNextTurn(playerList[0], enemyList[0], playerDialogue, enemyDialogue);

        //UIに表示
        this.uiPresenter.SetPlayerHealth(resultList);
        this.uiPresenter.SetCharcterList(playerList,enemyList);
    }



    private bool IsEnemyDefeated()
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

}