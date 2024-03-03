using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusView : MonoBehaviour,IStatusView
{
    public List<Text> CharacterStatusText;

    public void SetPlayerStatus(List<Character> playerList)
    {
        for (int i = 0; i < CharacterStatusText.Count; i++)
        {
            if(playerList.Count > i){
            CharacterStatusText[i].text = playerList[i].Name + "\n" + "HP:" + playerList[i].Hp + "\n" + "MP:" + playerList[i].Mp;
            }
            else
            {
                CharacterStatusText[i].text = "";
            }
        }

    }
}
