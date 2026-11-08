using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DreamInteraction : MonoBehaviour
{
    public GameObject dreamPanel;
    public DreamGUI GUI;
    public Movement player;
    public float delayPanel = 2f;

    // Flash
    public float gradiantDuration;
    public FlashTransition flash;

    private bool inRange = false;  
    private bool canFlash = true; 
    private bool panelOpen = false;
    Coroutine _currentRoutine = null;
    

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && inRange && !panelOpen && canFlash)
        {
            flash.StartFlash(gradiantDuration, gradiantDuration/2, 0.75f, Color.skyBlue);
            player.disableMovement(); 
            panelOpen = true;
            canFlash = false;

            _currentRoutine = StartCoroutine(dreamStart(delayPanel));
        }
        
        else if (Keyboard.current.eKey.wasPressedThisFrame && panelOpen && canFlash)
        {   
            flash.StartFlash(gradiantDuration, gradiantDuration/2, 0.75f, Color.yellow);
            player.enableMovement();
            panelOpen = false;
            canFlash = false;

            _currentRoutine = StartCoroutine(dreamClose(delayPanel));
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
        }
    }

IEnumerator dreamStart(float delay)
    {
        // wait beforemaking panel visible
        yield return new WaitForSeconds(delay);
       
        dreamPanel.SetActive(true);
        GUI.enablePanel();
        canFlash = true;
    }

    IEnumerator dreamClose(float delay)
    {
        // wait beforemaking panel go away
        yield return new WaitForSeconds(delay);
        GUI.disablePanel();
        canFlash = true;
    }
}
