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
        if ((Keyboard.current.eKey.wasPressedThisFrame || Keyboard.current.spaceKey.wasPressedThisFrame) && inRange && canFlash)
        {
            flash.StartFlash(gradiantDuration, gradiantDuration/2, 0.75f, Color.skyBlue);
            player.disableMovement(); 
            canFlash = false;

            StartCoroutine(DreamStart(delayPanel));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
        }
    }

IEnumerator DreamStart(float delay)
    {
        // wait beforemaking panel visible
        yield return new WaitForSeconds(delay);
       
        // dreamPanel.SetActive(true);
        GUI.EnablePanel();
        canFlash = false;
    }

    IEnumerator DreamClose(float delay)
    {
        // wait beforemaking panel go away
        flash.BlockInteraction();
        yield return new WaitForSeconds(delay);
        GUI.DisablePanel();
        flash.StopBlockInteraction();
    }

    public void EndDream(Color color)
    {
        flash.StartFlash(gradiantDuration, gradiantDuration/2, 0.75f, color);
        player.enableMovement();

        StartCoroutine(DreamClose(delayPanel));
    }
}
