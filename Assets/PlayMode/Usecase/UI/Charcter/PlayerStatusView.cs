using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusView : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
