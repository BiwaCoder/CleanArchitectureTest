using System.Collections.Generic;
using VContainer;
using UnityEngine;

//表示
public class BattlePresenter : IBattleOutputPort
{
    public readonly IBattleView _view;

    [Inject]
    public BattlePresenter(IBattleView view)
    {
        Debug.Log("BattlePresenter");

        _view = view;
    }

    public void PresentBattleResult(List<BattleResult> result)
    {
        _view.DisplayResult(result);
    }
}