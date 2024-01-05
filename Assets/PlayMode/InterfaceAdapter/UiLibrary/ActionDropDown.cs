using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ActionDropDown : MonoBehaviour
{
    private Dropdown _dropdown;

    void Start()
    {
    
        // Dropdown コンポーネントの取得
        _dropdown = GetComponent<Dropdown>();

        // ドロップダウンのオプション設定
        List<string> options = new List<string> {"行動を選択してください", "たたかう", "にげる", "ぼうぎょ" };
        _dropdown.AddOptions(options);

        // ドロップダウンの値が変更されたときのイベントリスナーを追加
        _dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    private void OnDropdownValueChanged(int index)
    {
        if(index == 0){
            Debug.Log("行動を選択してください");
        }
       else{
            Debug.Log("選択されたオプション: " + _dropdown.options[index].text);

            //イベントハンドラをキックする
       }
    }
}
