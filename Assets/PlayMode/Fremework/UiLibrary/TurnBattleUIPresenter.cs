using System.Diagnostics;
using UniRx;
using System.Collections.Generic;
using VContainer;

public class TurnBattleUIPresenter : ITurnBattleOutputPort
{
    private TurnBattleView _view;
    private TurnBattleModel _model;

    [Inject]
    public TurnBattleUIPresenter(TurnBattleView view,TurnBattleModel model)
    {
        _view = view;
        _view.SetPresenter(this);
         //_statusPresenter = statusPresenter;
        _model = model;

        _model.PlayerHealth.Subscribe(health => _view.SetPlayerHealth(health)).AddTo(_view);
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


    //public void SetCharcterList(List<Character> playerList, List<Character> enemyList)
    //{
    //    _statusPresenter.ViewStatus(playerList,enemyList);;
    //}

}
