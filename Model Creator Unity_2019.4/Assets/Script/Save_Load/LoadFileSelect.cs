using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFileSelect : MonoBehaviour
{
    public void OnLoadFile_1()
    {
        LoadFileState(new bool[] { true, false, false, false, false, false });
    }

    public void OnLoadFile_2()
    {
        LoadFileState(new bool[] { false, true, false, false, false, false });
    }

    public void OnLoadFile_3()
    {
        LoadFileState(new bool[] { false, false, true, false, false, false });
    }

    public void OnLoadFile_4()
    {
        LoadFileState(new bool[] { false, false, false, true, false, false });
    }

    public void OnLoadFile_5()
    {
        LoadFileState(new bool[] { false, false, false, false, true, false });
    }

    public void OnLoadFile_6()
    {
        LoadFileState(new bool[] { false, false, false, false, false, true });
    }

    private void LoadFileState(bool[] state)
    {
        var selectedFile = Interface._obj.GetSelectedFile();
        for (var i = 0; i < 6; i++)
            selectedFile[i] = state[i];
        Interface._obj.SetSelectedFile(selectedFile);

        Interface._obj.SetSavedFile(true);
        Interface._obj.SetTempFile(false);

        Interface._obj.SetModelCreateScene(true);
        SceneManager.LoadScene("SceneLoading");
    }
}
