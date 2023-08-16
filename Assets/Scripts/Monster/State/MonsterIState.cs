using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MonsterIState
{
    public void Enter();
    public void Update();
    public void FixedUpdate();
    public void Exit();
}
