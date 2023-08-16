using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : SingletonAutoMono<MonsterManager>
{
    public float restTime = 3f;//µ–»ÀÕ£÷π ±º‰
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartRest()
    {
        StartCoroutine("Rest");
    }

    IEnumerator Rest()
    {
        yield return new WaitForSeconds(restTime);
        EventCenter.GetInstance().EventTrigger(E_EventC.MonsterRest);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
