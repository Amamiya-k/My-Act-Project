using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterObject : MonoBehaviour,IHitAgent
{
    public Animator animator;
    public NavMeshAgent agent;
    public EnemyData enemyData;

    public float maxHealth;
    public float currentHealth;

    protected MonsterStateMachine stateMachine;

    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
        agent = GetComponent<NavMeshAgent>();

        maxHealth = enemyData.MaxHealth;
        currentHealth = maxHealth;

        stateMachine = new MonsterStateMachine();
        stateMachine.Init(this);

        EnemyManager.GetInstance().EnemyRegister(this);
    }

    public void GetDamage(int dmg, float dir)
    {
       
        currentHealth = Mathf.Max(0, currentHealth - dmg);
        print(currentHealth);
        if (currentHealth == 0)
        {
            stateMachine.ChangeState(E_EnemyState.DeadState);
        }
        else animator.CrossFade("LightHitF", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }
}
