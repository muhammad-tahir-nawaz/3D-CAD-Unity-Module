using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RayCasts
{
    public bool GraphicRaycast(string objToFind, EventSystem eventSystem)
    {
        //Fetch the canvas
        var canvas = Interface._obj.GetClassRefrence_UPV().GetCanvas();
        //Fetch the Raycaster from the GameObject (the Canvas)
        var raycaster = canvas.GetComponent<GraphicRaycaster>();

        // Set up the new Pointer Event
        var pointerEventData = new PointerEventData(eventSystem)
        {
            //Set the Pointer Event Position to that of the mouse position
            position = Input.mousePosition
        };

        // Create a list of Raycast Results
        var results = new List<RaycastResult>();

        // Raycast using the Graphics Raycaster and mouse click position
        raycaster.Raycast(pointerEventData, results);

        // For every result returned, output the name of the GameObject on the Canvas hit by the Ray
        foreach (RaycastResult result in results)
        {
            if (result.gameObject.name == objToFind)
            {
                return true;
            }
        }
        return false;
    }

}
