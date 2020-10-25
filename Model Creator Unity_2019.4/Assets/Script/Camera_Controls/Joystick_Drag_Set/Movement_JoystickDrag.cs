using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Movement_JoystickDrag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Interface._obj.SetMoveJoystickDrag(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Interface._obj.SetMoveJoystickDrag(false);
    }
}
