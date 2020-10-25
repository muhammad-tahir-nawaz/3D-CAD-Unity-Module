using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ModelObjLength_Inc : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var gameObj = Active_UIElements._obj.GetActiveElementParent();
        gameObj.transform.localScale += new Vector3(0,0,5);

        var modelObj = InstantiatedGameObject._obj.GetInstantiatedModelObj(gameObj);
        modelObj.SetScale(modelObj.GetScale() + new Vector3(0, 0, 5));
        modelObj.SetObjLength(modelObj.GetObjLength() + 5);

    }
}
