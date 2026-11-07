using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UIElements;

public class DreamGUI : MonoBehaviour
{
    private PanelRenderer panelRenderer; 
    private Button correctItem;
    private Button[] incorrectItems;
    private int uiVersion = 0;

    void Awake()
    {
        GetComponent<PanelRenderer>().RegisterUIReloadCallback(OnUIReload);
    }

     private void OnUIReload(PanelRenderer panelRenderer, VisualElement root, int version)
    {
        // The version number only changes when the UI actually reloads, 
        // so this checks prevents duplicated elements.
        if (uiVersion == version)
            return;
        uiVersion = version;
        correctItem = root.Q<Button>("correctItem");
        correctItem.RegisterCallback<ClickEvent>(correctItemClicked);
    }

    private void OnEnable()
    {

    }

    private void correctItemClicked(ClickEvent evt)
    {
        Debug.Log("THAT WAS RIGHT!");
    }


}
