using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : BasePanel
{
    public Button buttonBack;

    public Slider sliderMusic;
    public Slider sliderSound;

    // Start is called before the first frame update

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIMgr.GetInstance().ClosePanel("SettingPanel");
        }*/
    }

    public void OnBtnClickEsc()
    {
        UIMgr.GetInstance().ClosePanel("SettingPanel");
    }

    public void SliderMusic()
    {
        MusicMgr.GetInstance().ChangeMusicValue(sliderMusic.value);
    }
    public void SliderSound()
    {
        MusicMgr.GetInstance().ChangeSoundValue(sliderSound.value);
    }
}
