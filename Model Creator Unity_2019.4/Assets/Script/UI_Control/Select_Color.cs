using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Select_Color : MonoBehaviour, IPointerClickHandler
{   
    public void OnPointerClick(PointerEventData eventData)
    {
        Interface._obj.SetSelectedColor(this.gameObject.GetComponent<Image>().color);
    }



}
