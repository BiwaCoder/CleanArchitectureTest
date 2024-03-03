using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class BattleInitializer {
    private static readonly Lazy<PlayerFactory> _playerFactory = new Lazy<PlayerFactory>(() => new PlayerFactory());
    private static readonly Lazy<EnemyFactory> _enemyFactory = new Lazy<EnemyFactory>(() => new EnemyFactory());


    //private static PlayerFactory _playerFactory;
    //private static EnemyFactory _enemyFactory;

    /*
    public  BattleInitializer(PlayerFactory playerFactory,EnemyFactory enemyFactory)
    {
        _playerFactory = playerFactory;
        _enemyFactory = enemyFactory;
    }*/

    public static List<Character> InitializePlayer()
    {
        var playerList = _playerFactory.Value.CreatePlayer();
        return playerList;
    }

    public static List<Character> InitializeEnemy(int i)
    {
        var enemyList = _enemyFactory.Value.CreateEnemy(i);
        return enemyList;
    }

}


