using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleInitializer {

    private PlayerFactory _playerFactory;
    private EnemyFactory _enemyFactory;

    public BattleInitializer(PlayerFactory playerFactory,EnemyFactory enemyFactory)
    {
        _playerFactory = playerFactory;
        _enemyFactory = enemyFactory;
    }

    public List<Character> InitializePlayer()
    {
        var playerList = _playerFactory.CreatePlayer();
        return playerList;
    }

    public List<Character> InitializeEnemy()
    {
        var enemyList = _enemyFactory.CreateEnemy();
        return enemyList;
    }

}


