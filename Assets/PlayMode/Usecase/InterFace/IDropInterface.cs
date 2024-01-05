using System;

public interface IDropInterface
{
    public void SetInteractor(TurnBasedBattleInteractor interactor,Action<int> callback);
       

    public void OnDropdownValueChanged(int index);
}
