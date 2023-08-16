using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class EnemyManager : SingletonAutoMono<EnemyManager>
{
    public int enemyDeadCount = 0;
    public int enemyCount = 0;
    public float time = 5;
    public float timer = 0;

    private void Update()
    {
        
    }

    

    

    public void EnemyRegister(MonsterObject monsterObject)
    {
        enemyCount++;
        print("enemyCount "+enemyCount);
    }

}
