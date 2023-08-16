using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class AttackDetection : MonoBehaviour
{
    public List<string> targetTags = new List<string>();
    public List<Collider> targets = new List<Collider>();
    public List<Collider> result = new List<Collider>();
    public void ClearDetectionTarget()
    {
        targets.Clear();
        result.Clear();
    }// => 
    public abstract List<Collider> GetDetectionTarget();
}
