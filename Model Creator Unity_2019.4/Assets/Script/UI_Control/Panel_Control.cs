using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_Control : MonoBehaviour
{
    private GameObject decorationPanel;
    private GameObject furniturePanel;
    private GameObject modelPanel;
    private GameObject colorPanel;
    private GameObject savePanel;


    // Start is called before the first frame update
    void Start()
    {
        decorationPanel = Interface._obj.GetClassRefrence_UPV().GetDecorationPanel();
        furniturePanel = Interface._obj.GetClassRefrence_UPV().GetFurniturePanel();
        modelPanel = Interface._obj.GetClassRefrence_UPV().GetWindowPanel();
        colorPanel = Interface._obj.GetClassRefrence_UPV().GetColorPanel();
        savePanel = Interface._obj.GetClassRefrence_UPV().GetSavePanel();

        Interface._obj.GetClassRefrence_UPV().GetObjectInfo().SetActive(false); // Setting objectInfo panel to disabled

        SetPanelState(new bool[] {false, false, false, false, false});
    }

    //Sets panels active or otherwise
    private void SetPanelState(bool[] state)
    {
        decorationPanel.SetActive(state[0]);
        furniturePanel.SetActive(state[1]);
        modelPanel.SetActive(state[2]);
        colorPanel.SetActive(state[3]);
        savePanel.SetActive(state[4]);

        CheckPanelState();
    }

    private void CheckPanelState()
    {
        if(decorationPanel.activeSelf == false && furniturePanel.activeSelf == false && modelPanel.activeSelf == false &&
            colorPanel.activeSelf == false && savePanel.activeSelf == false)
        {
            Interface._obj.SetPanelActive(false);
        }
        else
        {
            Interface._obj.SetPanelActive(true);
        }

    }

    public void OnDecorationClick()
    {
        SetPanelState(new bool[] { !decorationPanel.activeSelf, false, false, false, false });

        Interface._obj.SetApplyColor(false);
        Interface._obj.SetActivePanelName("Decoration_Panel");
    }

    public void OnFuritureClick()
    {
        SetPanelState(new bool[] { false, !furniturePanel.activeSelf, false, false, false });

        Interface._obj.SetApplyColor(false);
        Interface._obj.SetActivePanelName("Furniture_Panel");
    }

    public void OnWindowClick()
    {
        SetPanelState(new bool[] { false, false, !modelPanel.activeSelf, false, false });

        Interface._obj.SetApplyColor(false);
        Interface._obj.SetActivePanelName("Model_Panel");
    }

    public void OnColorClick()
    {
        SetPanelState(new bool[] { false, false, false, !colorPanel.activeSelf, false });

        Interface._obj.SetApplyColor(!Interface._obj.GetApplyColor());
        Interface._obj.SetActivePanelName("Color_Panel");
    }

    public void OnSaveClick()
    {
        SetPanelState(new bool[] { false, false, false, false, !savePanel.activeSelf });

        Interface._obj.SetApplyColor(false);
        Interface._obj.SetActivePanelName("Save_Panel");
    }

}
