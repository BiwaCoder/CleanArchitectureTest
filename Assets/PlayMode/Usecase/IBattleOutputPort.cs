using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface  IBattleOutputPort 
{
    void PresentBattleResult(List<BattleResult> result);
}
