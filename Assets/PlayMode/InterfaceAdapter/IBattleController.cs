using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBattleController 
{

    public void StartBattle(Character player, Character enemy,CharacterDialogue playerDialogue,CharacterDialogue enemyDialogue);
}
