using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CharcterRepository 
{
    public static Character LoadCharcterData(int id)
    {
        if (id == 1)
        {
            Character character = new Character();
            character.Name = "Player";
            character.id = 1;    
            character.Hp = 100;
            character.Mp = 100;
            character.Atk = 30;
            character.Def = 10;
            character.Speed = 10;
            return character;
        }
        else if (id == 2)
        {
            Character character = new Character();
            character.Name = "Enemy";
            character.id = 2;    
            character.Hp = 100;
            character.Mp = 100;
            character.Atk = 10;
            character.Def = 5;
            character.Speed = 10;

            return character;
        }
        else
        {
            return null;
        }
    }
}
