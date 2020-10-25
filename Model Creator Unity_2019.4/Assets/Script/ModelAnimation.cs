using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelAnimation : MonoBehaviour
{
    private int iterator;
    // Start is called before the first frame update
    void Start()
    {
        iterator = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Interface._obj.GetSceneLoaded())
        {

            var list = InstantiatedGameObject._obj.GetInstantiatedModelObjList();
            foreach (GameObject_Model modelObj in list)
            {
                modelObj.GetGameObject().transform.localScale += new Vector3(0, 0.5f, 0);
                modelObj.SetScale(modelObj.GetScale() + new Vector3(0, 0.5f, 0));
            }

            iterator++;
            if (iterator == 120)
            {
                Interface._obj.SetSceneLoaded(false);
                iterator = 0;
            }
                

        }
    }
}
