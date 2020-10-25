using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SavedFileCheck : MonoBehaviour
{
    public Button loadFile_1;
    public Button loadFile_2;
    public Button loadFile_3;
    public Button loadFile_4;
    public Button loadFile_5;
    public Button loadFile_6;

    // Start is called before the first frame update
    void Start()
    {
        loadFile_1.interactable = false;
        loadFile_2.interactable = false;
        loadFile_3.interactable = false;
        loadFile_4.interactable = false;
        loadFile_5.interactable = false;
        loadFile_6.interactable = false;

        string path;
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = null;
        SaveFilesData saveData;


        var fileData = new bool[6];
        var fileName = new string[6];
        for (var iter = 0; iter < 6; iter++)
        {
            path = Application.persistentDataPath + ("/file" + (iter + 1) + "Data.save");
            if (File.Exists(path))
            {
                stream = new FileStream(path, FileMode.Open);

                saveData = formatter.Deserialize(stream) as SaveFilesData;
                fileData[iter] = saveData.FileData;
                fileName[iter] = saveData.FileName;

            }
            else
            {
                fileData[iter] = false;
            }
        }
        stream.Close();

        SetInteractable(loadFile_1, fileData[0], fileName[0]);
        SetInteractable(loadFile_2, fileData[1], fileName[1]);
        SetInteractable(loadFile_3, fileData[2], fileName[2]);
        SetInteractable(loadFile_4, fileData[3], fileName[3]);
        SetInteractable(loadFile_5, fileData[4], fileName[4]);
        SetInteractable(loadFile_6, fileData[5], fileName[5]);


    }

    private void SetInteractable(Button loadButton, bool fileData, string fileName)
    {
        if (fileData)
        {
            loadButton.interactable = true;
            loadButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = fileName;
        }
    }


}
