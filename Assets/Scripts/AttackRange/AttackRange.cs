using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    public List<Collider> targets = new List<Collider>();
    public List<Collider> results = new List<Collider>();

    public int index;
    public Vector3 target;
    public float distance;

    public static AttackRange instance;
    private void Start()
    {
        targets = new List<Collider>();
        results = new List<Collider>();
        instance = this;
    }

    private void Update()
    {
       // print(results.Count);
       // GetAttackTarget(Vector3.zero);
    }

    public Vector3 GetAttackTarget(Vector3 playTransform)
    {
        //print(results.Count);
        
        if (results.Count == 0) return Vector3.zero;
        else
        {
            distance = Vector3.Distance(results[0].transform.position, playTransform);
            target = results[0].transform.position;
        }
        foreach (var item in results)
        {

            print(Vector3.Distance(item.gameObject.transform.position, playTransform));
            if (Vector3.Distance(item.gameObject.transform.position, playTransform) < distance)
            {
                index = results.IndexOf(item);
                target = item.transform.position;
                print(target);
            }
        }
        return target;
    }

    /*   public void OnTriggerStay(Collider collider)
       {
           if (!targets.Contains(collider))
           {
               targets.Add(collider);
           }
           foreach (Collider item in targets)
           {
               AgentHitBox hitBox;

               if (item.TryGetComponent(out hitBox)
               //&& hitBox.agent != null
                   && hitBox.gameObject.tag == E_DeteTag.Monster.ToString()
                    && !results.Contains(item))
               {
                   print(item);
                   results.Add(item);
               }
           }
       }
   */

    public void OnTriggerEnter(Collider collider)
    {
        AgentHitBox hitBox;
        if (collider.TryGetComponent(out hitBox)
            //&& hitBox.agent != null
            && hitBox.gameObject.tag == E_DeteTag.Monster.ToString()
             )//&& !results.Contains(collider)
        {
            results.Add(collider);
            //print(results.Count);
            //print(item.transform.position);
            //float res = Vector3.Dot(transform.forward, hitBox.gameObject.transform.forward);
            //Debug.Log(res);
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if(results.Contains(collider))
        {
            results.Remove(collider);
            print(results.Count);
        }
    }

   /* public void OnTriggerStay(Collider collider)
    {
        if (!targets.Contains(collider))
        {
            targets.Add(collider);
           
        }
        foreach (Collider item in targets)
        {
            AgentHitBox hitBox;
            if (item.TryGetComponent(out hitBox)
                //&& hitBox.agent != null
                && hitBox.gameObject.tag == E_DeteTag.Monster.ToString()
                 && !results.Contains(item))
            {
                results.Add(item);
                print(item.transform.position);
                //float res = Vector3.Dot(transform.forward, hitBox.gameObject.transform.forward);
                //Debug.Log(res);
            }
        }
    }*/


}
