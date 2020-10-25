using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectColor : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        Color color = Interface._obj.GetSelectedColor();
        if (Interface._obj.GetApplyColor() && color != null)
        {
            this.gameObject.GetComponent<Renderer>().material.color = color;
            InstantiatedGameObject._obj.GetInstantiatedModelObj(this.gameObject).SetColor(color);
        }
    }

}
