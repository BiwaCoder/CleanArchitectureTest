using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class TurnBattleView : MonoBehaviour
{
    public Text PlayerHealthText;
    
    // プレゼンターへの参照を保持
    private TurnBattleUIPresenter _presenter;

    public void SetPresenter(TurnBattleUIPresenter presenter)
    {
        _presenter = presenter;
    }

    public void SetPlayerHealth(string health)
    {
        PlayerHealthText.text = $"Player Health: {health}";
    }
}