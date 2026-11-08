using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DreamGUI : MonoBehaviour
{
    public PointTracker tracker;
    public DreamInteraction interaction;

    private UIDocument _doc; 
    private Button _correctItem;
    
    private int wrongCount;
    private bool hasFailed = false;


    void Awake()
    {
        _doc = GetComponent<UIDocument>();

        _correctItem = _doc.rootVisualElement.Q("CorrectItem") as Button;
        _correctItem.RegisterCallback<ClickEvent>(OnCorrectItemClick);

         _doc.rootVisualElement.style.display = DisplayStyle.None;

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

    void Update()
    {
        if (wrongCount >= 3 && !hasFailed)
        {
            hasFailed = true;
            tracker.incrementFailureCount();
            tracker.incrementPoints();
            interaction.endDream(Color.black);
        }
    }

    private void OnDisable()
    {
        _correctItem.UnregisterCallback<ClickEvent>(OnCorrectItemClick);
    }

    private void OnCorrectItemClick(ClickEvent evt)
    {
        Debug.Log("good job, Colin!");
        tracker.incrementPoints();
        interaction.endDream(Color.yellow);
    }
    private void OnIncorrectItemClick(ClickEvent evt)
    {
        Debug.Log("fuck you Colin");
        wrongCount++;
        Button pressedButton = evt.target as Button;
        pressedButton.SetEnabled(false);
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
