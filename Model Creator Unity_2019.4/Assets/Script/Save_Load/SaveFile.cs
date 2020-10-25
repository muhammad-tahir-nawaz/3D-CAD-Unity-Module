using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveFile : MonoBehaviour
{
    private string saveFileNo;
    private TMPro.TextMeshProUGUI textBox;

    // Generalized method to handeling the file saving/ overwriting
    public void FileSelect(GameObject gameObject)
    {
        this.textBox = gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        this.saveFileNo = textBox.name.Substring(15);

        if (!textBox.text.Contains("Save File"))
        {
            Interface._obj.GetClassRefrence_UPV().GetSubSavePanel().SetActive(false);
            Interface._obj.GetClassRefrence_UPV().GetOverwritePanel().SetActive(true);
        }
        else
        {
            PerformSave(saveFileNo);
        }
    }

    public void PerformOverwrite(bool overwrite)
    {
        if (overwrite)
            PerformSave(saveFileNo);

        Interface._obj.GetClassRefrence_UPV().GetSubSavePanel().SetActive(true);
        Interface._obj.GetClassRefrence_UPV().GetOverwritePanel().SetActive(false);
    }

    private void PerformSave(string fileNumber)
    {
        textBox.text = System.DateTime.Now.ToString("MM/dd/yyyy \nHH:mm:ss");

        StoreSaveFileData(new SaveFilesData(true, textBox.text), ("/file" + fileNumber + "Data.save"));
        StoreModelData(Application.persistentDataPath + ("/saveFile" + fileNumber + ".save"));

    }

    private void StoreModelData(string path)
    {
        var formatter = new BinaryFormatter();
        var writeStream = new FileStream(path, FileMode.Create);
        var binaryTemplate = new BinaryTemplate(Camera.main);

        formatter.Serialize(writeStream, binaryTemplate);
        writeStream.Close();
    }

    private void StoreSaveFileData(SaveFilesData fileData, string subPath)
    {
        string path = Application.persistentDataPath + subPath;

        var formatter = new BinaryFormatter();
        var stream = new FileStream(path, FileMode.OpenOrCreate);

        formatter.Serialize(stream, fileData);
        stream.Close();
    }

}
