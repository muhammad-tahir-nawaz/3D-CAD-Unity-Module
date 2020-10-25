using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectDelete : MonoBehaviour,  IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        var gameObject = Active_UIElements._obj.GetActiveElementParent();
        if(gameObject.name.Contains("wall") || gameObject.name.Contains("window") || gameObject.name.Contains("door"))
        {
            InstantiatedGameObject._obj.DeleteGameObjectModel(InstantiatedGameObject._obj.GetInstantiatedModelObj(gameObject));
            DestroyUIElement("UIElment_Dynamic_ModelObj(Clone)");
        }
        else
        {
            InstantiatedGameObject._obj.DeleteGameObjectInterior(InstantiatedGameObject._obj.GetInstantiatedInteriorObj(gameObject));
            DestroyUIElement("UIElment_Dynamic_InteriorObj(Clone)");
        }

        Destroy(gameObject);

    }

    private void DestroyUIElement(string objName)
    {
        Destroy(GameObject.Find(objName));

        Active_UIElements._obj.SetDynamicUIState(false);
        Active_UIElements._obj.SetActiveElementParent(null);
        Active_UIElements._obj.SetActiveUIElement(null);
    }

}
