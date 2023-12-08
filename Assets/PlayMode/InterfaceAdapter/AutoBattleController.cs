using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;

public class AutoBattleController : MonoBehaviour
{

    public IBattleController controller;

    [Inject]
    public void Inject(IBattleController hogeClass)
    {
        this.controller = hogeClass;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("AutoBattleController Start");
        //BattleInteractorやBattleActionを入れ替える
        //タップで進む

        //var view = new AutoBattleView();
        //var presenter = new BattlePresenter(view);
        //var interactor = new BattleInteractor(presenter);
        //var controller = new BattleController(interactor);
        
        var playerCharacter = CharcterRepository.LoadCharcterData(1);
        var enemyCharacter = CharcterRepository.LoadCharcterData(2);
        var playerDialogue = new CharacterDialogue("さぁバトルを始めよう！", "これでどうだ！");
        var enemyDialogue = new CharacterDialogue("お前に私が倒せるかな？", "くらえ！");
        controller.StartBattle(playerCharacter, enemyCharacter, playerDialogue, enemyDialogue); 
    }


}
