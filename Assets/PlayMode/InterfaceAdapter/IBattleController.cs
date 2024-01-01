using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBattleController 
{
    public void SetView(TurnBattleView view);
    public void GameInitialize();
}
