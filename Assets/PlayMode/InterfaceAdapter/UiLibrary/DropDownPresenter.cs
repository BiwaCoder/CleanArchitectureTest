using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DropDownPresenter : MonoBehaviour,IDropDownPresenter
{
  
    public GameObject CreateDropDown(Action<int> callback)
    {
        //マッププレハブのロード
        GameObject dropdownPrefab = Resources.Load<UnityEngine.GameObject>("Input/MapSelect");
        GameObject dropdownInstance = Instantiate(dropdownPrefab, transform);
        dropdownInstance.GetComponent<IDropInterface>().SetCallBack(callback); 
        return dropdownInstance;
    }

}
