using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class EnemyDropDown : MonoBehaviour
{
    private Dropdown _dropdown;

    void Start()
    {
        // プレハブのロード
        GameObject dropdownPrefab = Resources.Load<GameObject>("Input/MapSelect");
        GameObject dropdownInstance = Instantiate(dropdownPrefab, transform);

        // Dropdown コンポーネントの取得
        _dropdown = dropdownInstance.GetComponent<Dropdown>();

        // ドロップダウンのオプション設定
        List<string> options = new List<string> {"攻撃する敵をえらんでください", "スライム", "ドラキー", "ドラゴン" };
        _dropdown.AddOptions(options);

        // ドロップダウンの値が変更されたときのイベントリスナーを追加
        _dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    private void OnDropdownValueChanged(int index)
    {
        if(index == 0){
            Debug.Log("敵を選択してください");
        }
       else{
            Debug.Log("選択されたオプション: " + _dropdown.options[index].text);

            //イベントハンドラをキックする
       }
    }
}
