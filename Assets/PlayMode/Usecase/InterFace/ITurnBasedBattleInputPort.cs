using UnityEngine;
public interface ITurnBasedBattleInputPort
{

    void SettingPlayer();
    public void SelectMapAndInitializeEnemy(int i);
    void ExecuteTurn();
}