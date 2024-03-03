using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBattleController
{

    public void GameInitialize();
    public void HandleAttackPressed();
    public void SelectMap(int i);
}
