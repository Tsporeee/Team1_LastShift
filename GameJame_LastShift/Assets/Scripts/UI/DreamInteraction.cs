using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DreamInteraction : MonoBehaviour
{
    public GameObject dreamPanel;
    public Movement player;
    public float delayPanel = 2f;

    // Flash
    public float gradiantDuration;
    public FlashTransition flash;

    private bool inRange = false;   
    private bool panelOpen = false;

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && inRange && !panelOpen)
        {
            flash.StartFlash(gradiantDuration, gradiantDuration/2, 0.75f, Color.skyBlue);
            player.disableMovement();
            panelOpen = true;
            StartCoroutine(dreamStart(delayPanel));
        }
        
        else if (Keyboard.current.eKey.wasPressedThisFrame && panelOpen)
        {   
            flash.StartFlash(gradiantDuration, gradiantDuration/2, 0.75f, Color.yellow);
            player.enableMovement();
            panelOpen = false;
            StartCoroutine(dreamClose(delayPanel));
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
    }

    IEnumerator dreamClose(float delay)
    {
        // wait beforemaking panel go away
        yield return new WaitForSeconds(delay);
       
        dreamPanel.SetActive(false);
    }
}
