using UnityEngine;
using UnityEngine.UI;
using System;

public class TurnBattleInputView : MonoBehaviour
{
    public Button AttackButton;
    // Start is called before the first frame update

    public event Action OnAttackPressed;

    void Start()
    {
       AttackButton.onClick.AddListener(() => OnAttackPressed?.Invoke());
    }

}
