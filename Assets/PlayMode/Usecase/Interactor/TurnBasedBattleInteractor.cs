
using VContainer;
using System.Collections.Generic;
using System.Linq;
using System;

public class TurnBasedBattleInteractor : ITurnBasedBattleInputPort
{

    //ドメインモデル------------------------------------
    private List<Character> playerList = new List<Character>();
    private List<Character> enemyList = new List<Character>();
    private CharacterDialogue playerDialogue;
    private CharacterDialogue enemyDialogue;


    //リポジトリのインターフェース-------------------------------------
    private ICharacterFactory _charcterRepository;


    //ロジックのインターフェース-------------------------------------
    private IBattleActionInterface iBattleAction;


    //UIのインターフェース-------------------------------------
    private ITurnBattleOutputPort iTurnBattleOutputPort ;

    private IStatusOutputPort _statusOutputPort;
    

    [Inject]
    public TurnBasedBattleInteractor(ITurnBattleOutputPort outputPort,IStatusOutputPort statusPresenter, ICharacterFactory charcterRepository, IBattleActionInterface battleAction)
    {
        iTurnBattleOutputPort = outputPort;
        _charcterRepository = charcterRepository;
        iBattleAction = battleAction;
        _statusOutputPort = statusPresenter;
    }

    //プレイヤーの初期化
    public void SettingPlayer()
    {
        //プレイヤーの初期化
        playerList = _charcterRepository.InitializePlayer();
        var characterDialogs = _charcterRepository.InitCharcterDialog();
        playerDialogue = characterDialogs.Item1;
        enemyDialogue = characterDialogs.Item2;
   
        //プレイヤーHPの設定 
        this._statusOutputPort.ViewStatus(playerList,enemyList);    
    }

    //敵データの初期化、ドロップダウンでマップの選択に合わせてデータを反映
    public void SelectMapAndInitializeEnemy(int i)
    {
        enemyList = _charcterRepository.InitializeEnemy(i);
        this._statusOutputPort.ViewStatus(playerList,enemyList);             
    }

    //ターンを進行させる
    public void ExecuteTurn()
    {
        UnityEngine.Debug.Log("ExecuteTurn");
        if(IsEnemyDefeated())
        {
            UnityEngine.Debug.Log("敵を倒しているため戦闘をはじめられません。マップを移動してください");
            return;
        }

        var resultList = iBattleAction.GoNextTurn(playerList[0], enemyList[0], playerDialogue, enemyDialogue);

        //UIに表示
        this.iTurnBattleOutputPort.SetPlayerHealth(resultList);
        this._statusOutputPort.ViewStatus(playerList,enemyList);    
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