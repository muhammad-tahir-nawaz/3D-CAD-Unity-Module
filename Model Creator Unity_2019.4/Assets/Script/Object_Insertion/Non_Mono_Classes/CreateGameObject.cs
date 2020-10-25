using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGameObject
{
    // For Objects that are part of the model
    public GameObject InstantiateGameObj(GameObject prefab, Vector3 startPosition, bool isWindow)
    {
        var gameObject = GameObject.Instantiate(prefab, startPosition, Quaternion.identity);
        gameObject.AddComponent<ObjectColor>();// Attaching ObjectColor script
        gameObject.AddComponent<ObjectReplace_Model>();// Attaching ObjectReplace_Model script
        gameObject.AddComponent<ObjectDrag>();// Attaching ObjectDrag script///    TO BE REMOVED
        gameObject.AddComponent<Instantiate_UIElement_ModelObj>();//  Attaching ElementInstantiation script

        gameObject.GetComponent<ObjectDrag>().enabled = false;// Disabling the script

        return gameObject;
    }

    public GameObject GameObjSetting(GameObject gameObject, Vector3 objLength, Vector3 objAngle, Color objColor)
    {
        // Assigning Object Length
        gameObject.transform.localScale += objLength;
        // Assigning Object Angle
        gameObject.transform.Rotate(objAngle);
        // Assigning Object Color
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", objColor);

        return gameObject;
    }

    // For Objects that are part of decoration (furniture, pots etc)
    public GameObject InstantiateGameObj(GameObject prefab, Vector3 position)
    {
        var gameObject = GameObject.Instantiate(prefab, position, Quaternion.identity);
        gameObject.AddComponent<ObjectDrag>();// Adding ObjectDrag script
        gameObject.AddComponent<ObjectRotate>();// Adding ObjectRotate script///    TO BE REMOVED
        gameObject.AddComponent<Instantiate_UIElement_InteriorObj>();// Adding Instantiate_UIElement_InteriorObj script

        gameObject.GetComponent<ObjectDrag>().enabled = false;// Disabling the script

        return gameObject;
    }

    public GameObject GameObjSetting(GameObject gameObject, Vector3 angle)
    {
        // Assigning Object Angle
        gameObject.transform.Rotate(angle);

        return gameObject;
    }

}
