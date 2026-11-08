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
    

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && inRange && canFlash)
        {
            flash.StartFlash(gradiantDuration, gradiantDuration/2, 0.75f, Color.skyBlue);
            player.disableMovement(); 
            canFlash = false;

            StartCoroutine(dreamStart(delayPanel));
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
        canFlash = false;
    }

    IEnumerator dreamClose(float delay)
    {
        // wait beforemaking panel go away
        yield return new WaitForSeconds(delay);
        GUI.disablePanel();
    }

    public void endDream(Color color)
    {
        flash.StartFlash(gradiantDuration, gradiantDuration/2, 0.75f, color);
        player.enableMovement();

        StartCoroutine(dreamClose(delayPanel));
    }
}
