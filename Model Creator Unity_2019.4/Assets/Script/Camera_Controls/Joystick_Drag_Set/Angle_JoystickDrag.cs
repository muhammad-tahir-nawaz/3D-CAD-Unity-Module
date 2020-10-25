using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Angle_JoystickDrag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Interface._obj.SetRotJoystickDrag(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Interface._obj.SetRotJoystickDrag(false);
    }
}
