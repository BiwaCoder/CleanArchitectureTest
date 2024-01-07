using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TurnBattleModel 
{
    public ReactiveProperty<string> PlayerHealth { get; private set; }
    public ReactiveProperty<int> EnemyHealth { get; private set; }

    public TurnBattleModel()
    {
        PlayerHealth = new ReactiveProperty<string>("");
        EnemyHealth = new ReactiveProperty<int>(100);
    }

    public void SetPlayerHealth(string health)
    {
        PlayerHealth.Value = health;
    }
}
