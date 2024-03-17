using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusViewPresentor : IStatusOutputPort
{
    public PlayerStatusView characterStatusView;
    public EnemyStatusView enemyStatusView;

    public StatusViewPresentor(PlayerStatusView playerStatusView,EnemyStatusView enemyStatusView)
    {
        this.characterStatusView = playerStatusView;
        this.enemyStatusView = enemyStatusView;
    }

    public void ViewStatus(List<Character> playerListj,List<Character> enemyList)
    {
        characterStatusView.SetPlayerStatus(playerListj);
        enemyStatusView.SetPlayerStatus(enemyList);
    }
}
