using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DreamGUI : MonoBehaviour
{
    public int amountIncorrect; 
    private UIDocument _doc; 
    private Button _correctItem;
    
    void Awake()
    {
        _doc = GetComponent<UIDocument>();

        _correctItem = _doc.rootVisualElement.Q("CorrectItem") as Button;
        _correctItem.RegisterCallback<ClickEvent>(OnCorrectItemClick);

        string buttonNamePrefix = "Incorrect";
        List<Button> incorrectButtons = _doc.rootVisualElement.Query<Button>()
            .Where(b => b.name != null && b.name.StartsWith(buttonNamePrefix))
            .ToList();

        foreach (Button incorrect in incorrectButtons)
        {
            incorrect.RegisterCallback<ClickEvent>(OnIncorrectItemClick);
        }

       _doc.rootVisualElement.style.display = DisplayStyle.None;
    }

    private void OnDisable()
    {
        _correctItem.UnregisterCallback<ClickEvent>(OnCorrectItemClick);
    }

    private void OnCorrectItemClick(ClickEvent evt)
    {
        Debug.Log("good job, Colin!");
    }
    private void OnIncorrectItemClick(ClickEvent evt)
    {
        Debug.Log("fuck you Colin");
    }

    public void enablePanel()
    {
         _doc.rootVisualElement.style.display = DisplayStyle.Flex;
    }

    public void disablePanel()
    {
        _doc.rootVisualElement.style.display = DisplayStyle.None;
    }

}
