using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDialogue 
{
    public string StartBattleDialogue { get; set; }
    public string AttackDialogue { get; set; }

    public CharacterDialogue(string startBattleDialogue, string attackDialogue)
    {
        StartBattleDialogue = startBattleDialogue;
        AttackDialogue = attackDialogue;
    }
}
