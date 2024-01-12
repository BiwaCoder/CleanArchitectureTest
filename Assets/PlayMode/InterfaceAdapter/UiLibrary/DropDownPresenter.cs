using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DropDownPresenter : MonoBehaviour,IDropDownPresenter
{
  
    public GameObject CreateDropDown(Action<int> callback,GameObject parent)
    {
        //マッププレハブのロード
        GameObject dropdownPrefab = Resources.Load<UnityEngine.GameObject>("Input/MapSelect");
        GameObject dropdownInstance = Instantiate(dropdownPrefab, parent.transform);
        dropdownInstance.GetComponent<IDropInterface>().SetCallBack(callback); 
        return dropdownInstance;
    }

}
