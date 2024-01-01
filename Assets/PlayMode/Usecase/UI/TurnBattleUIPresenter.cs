using System.Diagnostics;
using UniRx;

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
        _model.EnemyHealth.Subscribe(health => _view.SetEnemyHealth(health)).AddTo(_view);
    }

    public void OnPlayerAttack()
    {
        _interactor.ExecuteTurn();
    }

    public void SetPlayerHealth(string health)
    {
        _model.SetPlayerHealth(health);
    }

    // その他のユーザーインタラクションを処理するメソッド
}
