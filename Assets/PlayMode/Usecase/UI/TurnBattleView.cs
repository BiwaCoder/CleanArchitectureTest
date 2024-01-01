using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class TurnBattleView : MonoBehaviour
{
    public Text PlayerHealthText;
    public Text EnemyHealthText;
    public Button AttackButton;

    // プレゼンターへの参照を保持
    private TurnBattleUIPresenter _presenter;

    public void SetPresenter(TurnBattleUIPresenter presenter)
    {
        _presenter = presenter;
    }

    void Start()
    {
        AttackButton.onClick.AddListener(() => _presenter.OnPlayerAttack());
    }

    public void SetPlayerHealth(string health)
    {
        PlayerHealthText.text = $"Player Health: {health}";
    }

    public void SetEnemyHealth(int health)
    {
        EnemyHealthText.text = $"Enemy Health: {health}";
    }
}