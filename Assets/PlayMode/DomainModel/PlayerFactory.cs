using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFactory 
{
    public List<Character> CreatePlayer()
    {
        List<Character> enemies = new List<Character>();
        
        //3体エネミーを作り、リストに追加する
        for (int i = 0; i < 3; i++)
        {
            Character player = CreatePlayerInstance();
            enemies.Add(player);
        }
    
        return enemies;
    }

    public　Character CreatePlayerInstance()
    {
        Character player = new Character();
        player.Name = "勇者";
        player.MaxHp = 100;
        player.Hp = 100;
        player.Atk = 8;
        player.Def = 3;
        player.Speed = 1;

        return player;
    }

}
