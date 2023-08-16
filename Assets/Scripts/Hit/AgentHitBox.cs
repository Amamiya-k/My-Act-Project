using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentHitBox : MonoBehaviour
{
    public GameObject hitBox;
    public IHitAgent agent;
    public void Awake()
    {
        hitBox = gameObject;
        agent = hitBox.GetComponent<IHitAgent>();
    }

    public void GetDamage(int dmg,float dir)
    {
        agent.GetDamage(dmg, dir);
    }
}
