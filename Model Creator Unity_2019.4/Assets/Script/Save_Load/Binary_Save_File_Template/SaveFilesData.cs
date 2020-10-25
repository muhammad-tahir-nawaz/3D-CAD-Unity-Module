using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveFilesData
{
    public bool FileData { get; set; }
    public string FileName { get; set; }

    public SaveFilesData(bool fileData, string fileName)
    {
        FileData = fileData;
        FileName = fileName;
    }
}
