using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObject_Model
{
    private GameObject gameObject;
    private Vector3 startPos;
    private Vector3 scale;
    private Vector3 angle;
    private Color color;
    private string objName;
    private double objLength;

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void SetGameObject(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }

    public void SetGameObject(GameObject gameObject, Vector3 startPos, Vector3 scale, Vector3 angle, Color color, string objName, double objLength)
    {
        this.gameObject = gameObject;

        this.startPos = startPos;
        this.scale = scale;
        this.angle = angle;
        this.color = color;
        this.objName = objName;
        this.objLength = objLength;
    }

    public Vector3 GetStartPos()
    {
        return startPos;
    }

    public void SetStartPos(Vector3 startPos)
    {
        this.startPos = startPos;
    }

    public Vector3 GetScale()
    {
        return scale;
    }

    public void SetScale(Vector3 scale)
    {
        this.scale = scale;
    }

    public Vector3 GetAngle()
    {
        return angle;
    }

    public void SetAngle(Vector3 angle)
    {
        this.angle = angle;
    }

    public Color GetColor()
    {
        return color;
    }

    public void SetColor(Color color)
    {
        this.color = color;
    }

    public string GetObjName()
    {
        return objName;
    }

    public void SetObjName(string objName)
    {
        this.objName = objName;
    }

    public double GetObjLength()
    {
        return objLength;
    }

    public void SetObjLength(double objLength)
    {
        this.objLength = objLength;
    }
}
