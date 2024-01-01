using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBattleView : IBattleView
{
   public void DisplayResult(List<BattleResult> result)
   {
        foreach (var battleResult in result)
        {
            Debug.Log(battleResult.HpStatusMessage);
            Debug.Log(battleResult.DamageMessage);
            //nullじゃないときだけ表示する
            if (battleResult.DefeatedMessage != null){
                Debug.Log(battleResult.DefeatedMessage);
            }
        }
   }
}
