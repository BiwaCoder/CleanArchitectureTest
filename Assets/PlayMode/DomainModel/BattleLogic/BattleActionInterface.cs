using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBattleActionInterface 
{
    public List<BattleResult> GoNextTurn(Character player, Character enemy,CharacterDialogue playerDialogue,CharacterDialogue enemyDialogue);
}
