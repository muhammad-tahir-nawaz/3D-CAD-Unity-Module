using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObject_Interior    
{
    private GameObject gameObject;
    private Vector3 position;
    private Vector3 angle;
    private string objName;

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void SetGameObject(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }

    public void SetGameObject(GameObject gameObject, Vector3 position, Vector3 angle, string objName)
    {
        this.gameObject = gameObject;
        this.position = position;
        this.angle = angle;
        this.objName = objName;
    }

    public Vector3 GetPosition()
    {
        return position;
    }

    public void SetPosition(Vector3 position)
    {
        this.position = position;
    }

    public Vector3 GetAngle()
    {
        return angle;
    }

    public void SetAngle(Vector3 angle)
    {
        this.angle = angle;
    }

    public string GetObjName()
    {
        return objName;
    }

    public void SetObjName(string objName)
    {
        this.objName = objName;
    }


}
