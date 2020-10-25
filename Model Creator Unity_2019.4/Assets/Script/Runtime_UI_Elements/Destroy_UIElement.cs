using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Destroy_UIElement : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

        if (Active_UIElements._obj.GetActiveElementParent() != null && Active_UIElements._obj.GetActiveUIElement() != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                var rayCast = new RayCasts();
                if(Active_UIElements._obj.GetModelObj())
                    if (!rayCast.GraphicRaycast("UIElment_Dynamic_ModelObj(Clone)", GetComponent<EventSystem>()))
                        DestroyUIElement("UIElment_Dynamic_ModelObj(Clone)");
               
                if(Active_UIElements._obj.GetInteriorObj())
                    if (!rayCast.GraphicRaycast("UIElment_Dynamic_InteriorObj(Clone)", GetComponent<EventSystem>()))
                    DestroyUIElement("UIElment_Dynamic_InteriorObj(Clone)");
            }
        }

    }

    private void DestroyUIElement(string objName)
    {
        Destroy(GameObject.Find(objName));
        
        Active_UIElements._obj.SetDynamicUIState(false);
        Active_UIElements._obj.SetActiveElementParent(null);
        Active_UIElements._obj.SetActiveUIElement(null);
    }
}
