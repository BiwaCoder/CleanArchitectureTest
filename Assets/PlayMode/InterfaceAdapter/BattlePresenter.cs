using System.Collections.Generic;

//表示
public class BattlePresenter : IBattleOutputPort
{
    private readonly IBattleView _view;

    public BattlePresenter(IBattleView view)
    {
        _view = view;
    }

    public void PresentBattleResult(List<BattleResult> result)
    {
        _view.DisplayResult(result);
    }
}