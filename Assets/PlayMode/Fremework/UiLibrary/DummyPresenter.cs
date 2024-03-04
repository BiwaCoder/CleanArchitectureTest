using System.Collections.Generic;


public class DummyPresenter : ITurnBattleOutputPort
{
    public void SetPlayerHealth(List<BattleResult> resultList){
        //ループしてログ出力
        foreach (var battleResult in resultList)
        {
            if (battleResult.DefeatedMessage != null){
                UnityEngine.Debug.Log($"{battleResult.HpStatusMessage} {battleResult.DamageMessage} {battleResult.DefeatedMessage}");
            }
            else
            {
                UnityEngine.Debug.Log($"{battleResult.HpStatusMessage} {battleResult.DamageMessage}");
            }
        }

    }

    public void SetCharcterList(List<Character> playerList, List<Character> enemyList){
            //ループしてログ出力
            foreach (var character in playerList)
            {
                UnityEngine.Debug.Log(character.Name);
            }
            foreach (var character in enemyList)
            {
                UnityEngine.Debug.Log(character.Name);
            }
    }

}
