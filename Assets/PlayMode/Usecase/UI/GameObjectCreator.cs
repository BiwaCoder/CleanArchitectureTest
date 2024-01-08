using System;
using System.Collections;
using System.Collections.Generic;
using Codice.Client.BaseCommands;
using UnityEngine;

public class GameObjectCreator : SingletonMonoBehaviour<GameObjectCreator>
{

    [SerializeField] private PlayerStatusView playerStatusView;

    [SerializeField] private EnemyStatusView enemyStatusView;

    private GameObject dropdownInstance;


    public PlayerStatusView GetView()
    {
        return playerStatusView;
    }

    public EnemyStatusView GetEnemyView()
    {
        return enemyStatusView;
    }

    public GameObject CreateDropDown(Action<int> callback)
    {
        //マッププレハブのロード
        GameObject dropdownPrefab = Resources.Load<UnityEngine.GameObject>("Input/MapSelect");
        dropdownInstance = Instantiate(dropdownPrefab, transform);
        dropdownInstance.GetComponent<IDropInterface>().SetCallBack(callback); 
        return dropdownInstance;
    }

    public void DestroyDropDown()
    {
        Destroy(dropdownInstance);
    }
    
}
