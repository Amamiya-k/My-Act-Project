using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePanel : BasePanel
{
    public void OnButtonClick(Button button)
    {
        EventCenter.GetInstance().EventTrigger<string>(E_EventC.LoadCharacter, button.name);
    }

    public void OnBtnClickEsc()
    {
        UIMgr.GetInstance().ClosePanel("ChoosePanel");
    }
}
