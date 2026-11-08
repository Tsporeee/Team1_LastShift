using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DreamGUI : MonoBehaviour
{
    public PointTracker tracker;
    public DreamInteraction interaction;

    public UIDocument doc; 
    public GameObject[] HP;
    public GameObject mommento;
    private Button _correctItem;
    
    private int wrongCount;
    private bool hasFailed = false;


    void Awake()
    {
        _correctItem = doc.rootVisualElement.Q("CorrectItem") as Button;
        _correctItem.RegisterCallback<ClickEvent>(OnCorrectItemClick);

         doc.rootVisualElement.style.display = DisplayStyle.None;

        string buttonNamePrefix = "Incorrect";
        List<Button> incorrectButtons = doc.rootVisualElement.Query<Button>()
            .Where(b => b.name != null && b.name.StartsWith(buttonNamePrefix))
            .ToList();

        foreach (Button incorrect in incorrectButtons)
        {
            incorrect.RegisterCallback<ClickEvent>(OnIncorrectItemClick);
        }
    }

    void Update()
    {
        if (wrongCount >= 3 && !hasFailed)
        {
            hasFailed = true;
            tracker.incrementFailureCount();
            tracker.incrementPoints();
            interaction.EndDream(Color.black);
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
        interaction.EndDream(Color.yellow);
    }
    private void OnIncorrectItemClick(ClickEvent evt)
    {
        Debug.Log("fuck you Colin");
        wrongCount++;
        Button pressedButton = evt.target as Button;
        pressedButton.SetEnabled(false);
        HP[HP.Length - wrongCount].SetActive(false);
    }

    public void EnablePanel()
    {
        doc.rootVisualElement.style.display = DisplayStyle.Flex;
        foreach (GameObject scissor in HP)
        {
            scissor.SetActive(true);
        }
    }

    public void DisablePanel()
    {
        doc.rootVisualElement.style.display = DisplayStyle.None;
        mommento.SetActive(true);
                foreach (GameObject scissor in HP)
        {
            scissor.SetActive(false);
        }
    }

}
