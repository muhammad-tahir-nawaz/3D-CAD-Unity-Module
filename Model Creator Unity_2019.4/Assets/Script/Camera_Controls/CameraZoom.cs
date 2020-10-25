using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private float targetZoom;
    private readonly float zoomFactor = 3f;
    private readonly float zoomLerpSpeed = 10f;

    private bool zoomIn = false;
    private bool zoomOut = false;

    private void Start()
    {
        targetZoom = Camera.main.fieldOfView;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (zoomIn)
        {
            targetZoom -= 1 * zoomFactor;
            targetZoom = Mathf.Clamp(targetZoom, 5, 95);// Lower, Upper Zoom Limit: 20, 100
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, targetZoom, Time.deltaTime * zoomLerpSpeed);
        }
        else if (zoomOut)
        {
            targetZoom += 1 * zoomFactor;
            targetZoom = Mathf.Clamp(targetZoom, 5, 95);// Lower, Upper Zoom Limit: 20, 100
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, targetZoom, Time.deltaTime * zoomLerpSpeed);
        }
    }

    public void OnDownZoomIn()
    {
        this.zoomIn = true;// Zooming in
        this.zoomOut = false;
    }

    public void OnDownZoomOut()
    {
        this.zoomIn = false;
        this.zoomOut = true;// Zooming out
    }

    public void OnButtonUp()
    {
        this.zoomIn = false;
        this.zoomOut = false;// Stop zoom function
    }

}
