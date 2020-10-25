using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is a Singleton Class.
public class Active_UIElements
{
    // Singleton variable
    public static readonly Active_UIElements _obj = new Active_UIElements();

    private GameObject activeElementParent;
    private GameObject activeUIElement;

    private bool dynamicUIState = false;
    private bool modelObj;
    private bool interiorObj;

    public GameObject GetActiveElementParent()
    {
        return activeElementParent;
    }
    public void SetActiveElementParent(GameObject activeElementParent)
    {
        this.activeElementParent = activeElementParent;
    }

    public GameObject GetActiveUIElement()
    {
        return activeUIElement;
    }
    public void SetActiveUIElement(GameObject activeUIElement)
    {
        this.activeUIElement = activeUIElement;
    }

    public bool GetDynamicUIState()
    {
        return dynamicUIState;
    }
    public void SetDynamicUIState(bool state)
    {
        this.dynamicUIState = state;
    }

    public bool GetModelObj()
    {
        return modelObj;
    }
    public void SetModelObj(bool state)
    {
        this.modelObj = state;
    }

    public bool GetInteriorObj()
    {
        return interiorObj;
    }
    public void SetInteriorObj(bool state)
    {
        this.interiorObj = state;
    }

}
