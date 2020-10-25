using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is a Singleton Class.
public class InstantiatedGameObject
{
    // Singleton variable
    public static readonly InstantiatedGameObject _obj = new InstantiatedGameObject();

    private List<GameObject_Model> instantiatedModelObj;
    private List<GameObject_Interior> instantiatedInteriorObj;

    InstantiatedGameObject() 
    {
        instantiatedModelObj = new List<GameObject_Model>();
        instantiatedInteriorObj = new List<GameObject_Interior>();
    }

    public void EmptyLists()
    {
        instantiatedModelObj = new List<GameObject_Model>();
        instantiatedInteriorObj = new List<GameObject_Interior>();
    }


    //Methods for instantiatedModelObj List
    public List<GameObject_Model> GetInstantiatedModelObjList()
    {
        return instantiatedModelObj;
    }

    public GameObject_Model GetInstantiatedModelObj(GameObject gameObject)
    {
        foreach (GameObject_Model modelObj in instantiatedModelObj)
        {
            if (GameObject.ReferenceEquals(gameObject, modelObj.GetGameObject()))
                return modelObj;
        }

        return null;
    }

    public void SetInstantiatedModelObj(GameObject_Model modelObj)
    {
        this.instantiatedModelObj.Add(modelObj);
    }

    public void DeleteGameObjectModel(GameObject_Model modelObj)
    {
        for(int i = 0; i < instantiatedModelObj.Count; i++)
        {
            if (GameObject.ReferenceEquals(modelObj.GetGameObject(), instantiatedModelObj[i].GetGameObject()))
                instantiatedModelObj.RemoveAt(i);
        }
    }

    public void AddGameObjectModel(GameObject_Model modelObj)
    {
        instantiatedModelObj.Add(modelObj);
    }


    //Methods for instantiatedInteriorObj List
    public List<GameObject_Interior> GetInstantiatedInteriorObjList()
    {
        return instantiatedInteriorObj;
    }

    public GameObject_Interior GetInstantiatedInteriorObj(GameObject gameObject)
    {
        foreach (GameObject_Interior interiorObj in instantiatedInteriorObj)
        {
            if (GameObject.ReferenceEquals(gameObject, interiorObj.GetGameObject()))
                return interiorObj;
        }

        return null;
    }

    public void SetInstantiatedInteriorObj(GameObject_Interior interiorObj)
    {
        this.instantiatedInteriorObj.Add(interiorObj);
    }

    public bool DeleteGameObjectInterior(GameObject_Interior interiorObj)
    {
        for (int i = 0; i < instantiatedInteriorObj.Count; i++)
        {
            if (GameObject.ReferenceEquals(interiorObj.GetGameObject(), instantiatedInteriorObj[i].GetGameObject()))
            {
                instantiatedInteriorObj.RemoveAt(i);
                return true;
            }
                
        }
        return false;
    }

    public void AddGameObjectInterior(GameObject_Interior interiorObj)
    {
        instantiatedInteriorObj.Add(interiorObj);
    }

}
