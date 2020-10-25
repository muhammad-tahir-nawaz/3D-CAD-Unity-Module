using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BackModelCreateScene : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    void Start()
    {
        if(!Interface._obj.GetBackButtonActive())
            this.gameObject.SetActive(false);

        Interface._obj.SetModelLoadScene(false); // To describe the settings for loading screen
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Interface._obj.SetSavedFile(false);
        Interface._obj.SetTempFile(true);

        Interface._obj.SetModelCreateScene(true);
        SceneManager.LoadScene("SceneLoading");
    }

}
