using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteriorObjAngle_CW : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
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
        gameObj.transform.localEulerAngles += new Vector3(0, 10, 0);

        var interiorObj = InstantiatedGameObject._obj.GetInstantiatedInteriorObj(gameObj);
        interiorObj.SetAngle(interiorObj.GetAngle() + new Vector3(0, 10, 0));
    }
}