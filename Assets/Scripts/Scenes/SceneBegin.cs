using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneBegin : MonoBehaviour
{
    Image start;
    private Color color1 = new Color(0, 0, 0, 255);
    // Start is called before the first frame update
    void Start()
    {
        start = GetComponent<Image>();
        start.DOColor(color1, 2f);        
        StartCoroutine(s());
        
    }
    IEnumerator s()
    {
        yield return new WaitForSeconds(3f);
        //ScenesMgr.GetInstance().LoadScene("stage0");
        ScenesMgr.GetInstance().LoadScene("BeginScene"); 
        //Destroy(this.gameObject);
        /*Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "BeginScene")
        {
            UIMgr.GetInstance().LoadPanel("BeginPanel");
        }*/
    }

 
}
