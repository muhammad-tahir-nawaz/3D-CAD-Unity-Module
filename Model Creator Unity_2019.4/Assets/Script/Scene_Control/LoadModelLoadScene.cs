using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class LoadModelLoadScene : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public static bool fromModelCreateScene;

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var formatter = new BinaryFormatter();
        var path = Application.persistentDataPath + ("/tempSave.save");
        var stream = new FileStream(path, FileMode.Create);

        var binaryTemplate = new BinaryTemplate(Camera.main);

        formatter.Serialize(stream, binaryTemplate);
        stream.Close();

        Interface._obj.SetBackButtonActive(true);
        Interface._obj.SetModelLoadScene(true);
        SceneManager.LoadScene("SceneLoading");
    }

}
