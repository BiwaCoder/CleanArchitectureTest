using System;

public interface IDropInterface
{
    public void SetCallBack(Action<int> callback);
       

    public void OnDropdownValueChanged(int index);
}
