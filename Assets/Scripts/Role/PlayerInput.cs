using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerInputAction inputActions { get; private set; }
    public PlayerInputAction.PlayerActions playerActions { get; private set; }

    private void Awake()
    {
        inputActions = new PlayerInputAction();
        playerActions = inputActions.Player; 
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

}
