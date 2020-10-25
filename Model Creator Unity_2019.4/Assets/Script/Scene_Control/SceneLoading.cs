using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    // Start is called before the first frame update
    private AsyncOperation asyncOperation;
    private AndroidPluginCallBack androidPlugin;

    [System.Obsolete]
    void Start()
    {
        if (!Interface._obj.GetModelLoadScene() && !Interface._obj.GetModelCreateScene())
        {
            androidPlugin = new AndroidPluginCallBack();

            if (androidPlugin.OpenModelLoadScene())
            {
                asyncOperation = Application.LoadLevelAsync("ModelLoad");
            }
            else
            {
                Interface._obj.SetSceneLoaded(true);
                asyncOperation = Application.LoadLevelAsync("ModelCreate");
            }
        }
        else
        {
            if (Interface._obj.GetModelLoadScene())
            {
                asyncOperation = Application.LoadLevelAsync("ModelLoad");
            }
            else if (Interface._obj.GetModelCreateScene())
            {
                Interface._obj.SetSceneLoaded(true);
                asyncOperation = Application.LoadLevelAsync("ModelCreate");
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (asyncOperation.isDone)
        {
            if (!Interface._obj.GetModelLoadScene() && !Interface._obj.GetModelCreateScene())
            {
                if (androidPlugin.OpenModelLoadScene())
                {
                    SceneManager.LoadScene("ModelLoad");
                }
                else
                {
                    SceneManager.LoadScene("ModelCreate");
                }
            }
            else
            {
                if (Interface._obj.GetModelLoadScene())
                {
                    SceneManager.LoadScene("ModelLoad");
                }
                else if (Interface._obj.GetModelCreateScene())
                {
                    SceneManager.LoadScene("ModelCreate");
                }
            }
        }
        
        
    }

}
