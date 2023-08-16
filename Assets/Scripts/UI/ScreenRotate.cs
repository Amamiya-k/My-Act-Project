using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.TestTools;

public class ScreenRotate : MonoBehaviour, IDragHandler
{
    
    public Vector2 rotate;

    private void Start()
    {
        
    }
    public void OnDrag(PointerEventData eventData)
    {

        //PlayerObject.instance.mainCameraTransform.Rotate(eventData.position);
        //
        rotate = eventData.delta;

        //CinemachineFreeLook freeLookCamera = Camera.main.GetComponent<CinemachineFreeLook>();

        //print(freeLookCamera.name);
        

    }


    


}
