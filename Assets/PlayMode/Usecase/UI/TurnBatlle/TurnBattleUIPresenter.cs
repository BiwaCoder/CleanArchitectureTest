using System.Diagnostics;
using UniRx;
using System.Collections.Generic;

public class TurnBattleUIPresenter
{
    private TurnBattleView _view;
    private TurnBattleModel _model;

    private TurnBasedBattleInteractor _interactor;

    public TurnBattleUIPresenter(TurnBattleView view,TurnBasedBattleInteractor interactor)
    {
        _view = view;
        _view.SetPresenter(this);
        _model = new TurnBattleModel();
        _interactor = interactor;

        // モデルの変更を購読して、ビューを更新する
        _model.PlayerHealth.Subscribe(health => _view.SetPlayerHealth(health)).AddTo(_view);
    }

    public void OnPlayerAttack()
    {
        _interactor.ExecuteTurn();
    }

    public void SetPlayerHealth(List<BattleResult> resultList)
    {

        string result ="";
        foreach (var battleResult in resultList)
        {
            if (battleResult.DefeatedMessage != null){
                result += $"{battleResult.HpStatusMessage} {battleResult.DamageMessage} {battleResult.DefeatedMessage}";
            }
            else
            {
                result += $"{battleResult.HpStatusMessage} {battleResult.DamageMessage}";
            }
        }


        _model.SetPlayerHealth(result);
    }


    public void SetCharcterList(List<Character> playerList, List<Character> enemyList)
    {
        PlayerStatusView data = GameObjectCreator.Instance.GetView();
        data.SetPlayerStatus(playerList);

        EnemyStatusView enemyData = GameObjectCreator.Instance.GetEnemyView();
        enemyData.SetPlayerStatus(enemyList);
    }

}
