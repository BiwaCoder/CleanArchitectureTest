using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharcterFactoryImpl : ICharacterFactory
{
    public List<Character> InitializePlayer()
    {
       PlayerFactory playerFactory = new PlayerFactory();
        return playerFactory.CreatePlayer();
    }

    public List<Character> InitializeEnemy(int i)
    {
        EnemyFactory enemyFactory = new EnemyFactory();
        return enemyFactory.CreateEnemy(i);
    }

    public (CharacterDialogue, CharacterDialogue) InitCharcterDialog()
    {
        var playerDialogue = new CharacterDialogue("さぁバトルを始めよう！", "これでどうだ！");
        var enemyDialogue = new CharacterDialogue("お前に私が倒せるかな？", "くらえ！");

        return (playerDialogue, enemyDialogue);
    }
}