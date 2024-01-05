using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class MapDropDown : MonoBehaviour, IDropInterface
{
    private Dropdown _dropdown;
    TurnBasedBattleInteractor _interactor;
    Action<int> _callback;

    void Start()
    {
        // Dropdown コンポーネントの取得
        _dropdown = this.GetComponent<Dropdown>();

        // ドロップダウンのオプション設定
        List<string> options = new List<string> {"行く場所を選択してください", "山", "畑", "路地裏" };
        _dropdown.AddOptions(options);

        // ドロップダウンの値が変更されたときのイベントリスナーを追加
        _dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }


    public void SetInteractor(TurnBasedBattleInteractor interactor,Action<int> callback)
    {
        _interactor = interactor;
        _callback = callback;
    }   

    public void OnDropdownValueChanged(int index)
    {
        if(index == 0){
            Debug.Log("行く場所を選択してください");
        }
       else{
            Debug.Log("選択されたオプション: " + _dropdown.options[index].text);
            _callback(index);
       }
    }
}
