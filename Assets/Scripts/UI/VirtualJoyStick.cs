using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.UI;

public class VirtualJoyStick : OnScreenControl, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Image imgTouchRect;

    private Image imgJoyStick;
    private Image imgHandle;

    [SerializeField]
    private float moveRange = 130;


    public void Start()
    {
        imgTouchRect = GetComponent<Image>();
        imgJoyStick = transform.Find("ImgJoyStick").GetComponent<Image>();
        imgHandle = transform.Find("ImgJoyStick").Find("ImgHandle").GetComponent <Image>();
        imgJoyStick.gameObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        imgJoyStick.gameObject.SetActive(true);

        Vector2 localPos;
        Vector2 localPos2;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(imgTouchRect.rectTransform,
           eventData.position, eventData.pressEventCamera, out localPos);

        imgJoyStick.transform.localPosition = localPos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(imgJoyStick.rectTransform,
           eventData.position, eventData.pressEventCamera, out localPos2);

        imgHandle.transform.localPosition = localPos2;

        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        SendValueToControl(Vector2.zero);
        imgHandle.transform.localPosition = Vector3.zero;
        imgJoyStick.gameObject.SetActive(false);
    }

    /*public void OnBeginDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }*/

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(imgJoyStick.rectTransform,
           eventData.position, eventData.pressEventCamera, out localPos);

        imgHandle.transform.localPosition = localPos;

        if(localPos.magnitude > moveRange)
        {
            imgHandle.transform.localPosition = localPos.normalized * moveRange;
        }

        var newPos = new Vector2(imgHandle.transform.localPosition.x / moveRange, imgHandle.transform.localPosition.y / moveRange);
        SendValueToControl(newPos);
    }


    [InputControl(layout = "Vector2")]
    [SerializeField]
    private string m_ControlPath;
    protected override string controlPathInternal
    {
        get => m_ControlPath;
        set => m_ControlPath = value;
    }

    /*public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }*/


}
