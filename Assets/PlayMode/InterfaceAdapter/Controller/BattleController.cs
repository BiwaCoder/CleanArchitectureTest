//入力をさばく
using UnityEngine;
using VContainer;

public class BattleController : MonoBehaviour
{
    public IBattleSystem _iBattleSystem;
    
    [Inject]
    public void InjectMethod(IBattleSystem battleSystem)
    {
        _iBattleSystem = battleSystem;
        Debug.Log($"BattleController{_iBattleSystem}");
    }


    // Start is called before the first frame update
    void Start()
    {
        //ゲームのほんと最初の開始処理
        GameInitialize();
    }

    public void GameInitialize()
    {
        _iBattleSystem.SettingPlayer();
    }

}
