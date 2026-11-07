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
            flash.StartFlash(gradiantDuration, gradiantDuration/2, 0.75f, Color.white);
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
