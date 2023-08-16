using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerIState
{
    public void Enter();
    public void Update();
    public void FixedUpdate();
    public void Exit();
}
