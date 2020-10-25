using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Disable_UIElements : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Interface._obj.GetPanelActive())
        {
            if (Input.GetMouseButtonDown(0))
            {
                var rayCast = new RayCasts();
                if (!rayCast.GraphicRaycast(Interface._obj.GetActivePanelName(), GetComponent<EventSystem>()))
                    DisablePanel(Interface._obj.GetActivePanelName());
            }
        }
    }

    private void DisablePanel(string panelName)
    {
        if(panelName != "Color_Panel")
        {
            GameObject.Find(panelName).SetActive(false);

            Interface._obj.SetPanelActive(false);

            Interface._obj.SetPanelRayCastDisable(true);
        }
        
    }
}
