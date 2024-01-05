using System;
using System.Collections;
using System.Collections.Generic;
using Codice.Client.BaseCommands;
using UnityEngine;

public class GameObjectCreator : SingletonMonoBehaviour<GameObjectCreator>
{
    private GameObject dropdownInstance;

    public GameObject CreateDropDown(TurnBasedBattleInteractor interactor,Action<int> callback)
    {
        //マッププレハブのロード
        GameObject dropdownPrefab = Resources.Load<UnityEngine.GameObject>("Input/MapSelect");
        dropdownInstance = Instantiate(dropdownPrefab, transform);
        dropdownInstance.GetComponent<IDropInterface>().SetInteractor(interactor,callback); 
        return dropdownInstance;
    }

    public void DestroyDropDown()
    {
        Destroy(dropdownInstance);
    }
    
}
