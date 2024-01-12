using UnityEngine;
using System;

public interface IDropDownPresenter 
{
    public GameObject CreateDropDown(Action<int> callback,GameObject parent);
}
