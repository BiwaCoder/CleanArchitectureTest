using System.Collections.Generic;
using VContainer;

//表示
public class BattlePresenter : IBattleOutputPort
{
    private readonly IBattleView _view;

    [Inject]
    public BattlePresenter(IBattleView view)
    {
        _view = view;
    }

    public void PresentBattleResult(List<BattleResult> result)
    {
        _view.DisplayResult(result);
    }
}