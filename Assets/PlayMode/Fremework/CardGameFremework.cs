using UnityEngine;
using VContainer;


public class CardGameFremework : MonoBehaviour
{

    public TurnBattleInputView _turnBattleInputView;

    public IDropDownPresenter dropDownInteractor;
    
    public IBattleController _battleController;
        
    [Inject]
    public void InjectMethod(IBattleController controller,IDropDownPresenter dropDownPresentor)
    {
        this._battleController = controller;
        this.dropDownInteractor = dropDownPresentor;
    }

    // Start is called before the first frame update
    void Start()
    {
        _battleController.GameInitialize();
        _turnBattleInputView.OnAttackPressed += _battleController.HandleAttackPressed;

        dropDownInteractor.CreateDropDown((int i)=>{ 
            UnityEngine.Debug.Log($"OnDropdownValueChanged:{i}"); 
            _battleController.SelectMap(i);
        },this.gameObject);
    }
    

}
