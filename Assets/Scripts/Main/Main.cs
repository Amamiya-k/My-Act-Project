using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        Init();
    }
    void Start()
    {
        
        StartCoroutine(Load());
        EventCenter.GetInstance().AddEventListener<string>(E_EventC.LoadCharacter, LoadScene);
    }

    public void LoadScene(string s)
    {
        ScenesMgr.GetInstance().LoadScene("GameScene");
    }

    private IEnumerator Load()
    {
        yield return new WaitForSeconds(1);
        UIMgr.GetInstance().LoadPanel("BeginPanel");
    }

    public void Init()
    {
        UIMgr.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
