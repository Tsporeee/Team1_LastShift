using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DreamInteraction : MonoBehaviour
{
    public GameObject dreamImage;
    public float gradiantDuration;
    public FlashTransition flash;
    private bool inRange = false;

    void Update()
    {
        if (Keyboard.current.eKey.isPressed && inRange)
        {
            flash.StartFlash(gradiantDuration, 0.50f, 0.25f, Color.white);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
        }
    }
}
