using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DreamInteraction : MonoBehaviour
{
    public GameObject dreamPanel;
    public DreamGUI GUI;
    public Movement player;
    public float delayPanel = 5f;

    // Flash
    public float gradiantDuration;
    public FlashTransition flash;

    public GameObject scissors; 
    public GameObject E;
    public SpriteRenderer scissorRenderer;
    public float targetScissorMove;
    public float scissorSpeed = 1;
    public Sprite closedScissors;

    public GameObject bottomRope;
    public float targetRopeMove = -1f;

    private bool inRange = false;  
    private bool canFlash = true; 
    

    void Update()
    {
        if ((Keyboard.current.eKey.wasPressedThisFrame || Keyboard.current.spaceKey.wasPressedThisFrame) && inRange && canFlash)
        {
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
            if (canFlash)
            {
                E.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
            E.SetActive(false);
        }
    }

IEnumerator DreamStart(float delay)
    {
        scissors.SetActive(true);
        E.SetActive(false);
        StartCoroutine(scissorsCut());
        flash.StartFlash(gradiantDuration, gradiantDuration/2, 0.75f, Color.skyBlue);

        // wait beforemaking panel visible
        yield return new WaitForSeconds(delay);
       
        // dreamPanel.SetActive(true);
        GUI.EnablePanel();
        scissors.SetActive(false);
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
        IEnumerator scissorsCut()
    {
        Vector3 positionThisFrame = scissors.transform.position; 
        for (float t = 0; t <= 1; t += Time.deltaTime)
        {
            float newX = Mathf.Lerp (positionThisFrame.x, targetScissorMove, t / scissorSpeed);
            scissors.transform.position = new Vector3(newX, positionThisFrame.y, positionThisFrame.z);

            // wait until the next frame
            yield return null;
        }
        scissorRenderer.sprite = closedScissors;
        
        Vector3 ropePosition = bottomRope.transform.position;  
        for (float t = 0; t <= 1; t += Time.deltaTime)
        {
            float newY = Mathf.Lerp (ropePosition.y, targetRopeMove, t / 0.75f);
            bottomRope.transform.position = new Vector3(ropePosition.x, newY, ropePosition.z);

            // wait until the next frame
            yield return null;
        }

    }    

}
