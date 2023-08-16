using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginPanel : BasePanel 
{
    public Button buttonStart;
    public Button buttonSetting;
    public Button buttonQuit;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(M());
    }

    IEnumerator M()
    {
        yield return new WaitForSeconds(1f);
        //MusicMgr.GetInstance().PlayMusic("ÑÌÔÆ");
    }


    public void OnButtonClickStart()
    {
        UIMgr.GetInstance().LoadPanel("ChoosePanel");
        //ScenesMgr.GetInstance().LoadScene("GameScene");
        //MusicMgr.GetInstance().PlaySound("µã»÷");
    }

    public void OnButtonClickSetting()
    {
        UIMgr.GetInstance().LoadPanel("SettingPanel");
    }

    public void OnButtonClickQuit()
    {
        Application.Quit();
    }

    // Update is called once per frame


}
