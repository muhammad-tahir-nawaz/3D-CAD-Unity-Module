using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidPluginCallBack
{
    AndroidJavaClass pluginClass;
    AndroidJavaObject pluginInstance;

    public AndroidPluginCallBack()
    {
        pluginClass = new AndroidJavaClass("com.example.integratedapp.UnityCallBack");
        pluginInstance = pluginClass.CallStatic<AndroidJavaObject>("getInstance");
    }

    public string GetJSONString()
    {
        return pluginInstance.Call<string>("jSONStringToUnity");
    }

    public bool OpenModelLoadScene()
    {
        return pluginInstance.Call<bool>("openModelLoadScene");
    }
}
