using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterRepository 
{
    public List<Character> InitializePlayer();
    public List<Character> InitializeEnemy(int i);

    public (CharacterDialogue, CharacterDialogue) InitCharcterDialog();
 
}
