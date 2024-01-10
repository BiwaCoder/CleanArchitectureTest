using System.Diagnostics;
using UniRx;
using System.Collections.Generic;
using VContainer;

public class TurnBattleUIPresenter
{
    private TurnBattleView _view;
    private TurnBattleModel _model;

    //private TurnBasedBattleInteractor _interactor;

    private iStatusPresenter _statusPresenter;

    [Inject]
    public TurnBattleUIPresenter(TurnBattleView view,iStatusPresenter statusPresenter)
    {
        _view = view;
        _statusPresenter = statusPresenter;

        _view.SetPresenter(this);
        _model = new TurnBattleModel();
        // モデルの変更を購読して、ビューを更新する
        _model.PlayerHealth.Subscribe(health => _view.SetPlayerHealth(health)).AddTo(_view);

        //_interactor = interactor;
    }

    public void OnPlayerAttack()
    {
        //_interactor.ExecuteTurn();
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
        _statusPresenter.ViewStatus(playerList,enemyList);;
    }

}
