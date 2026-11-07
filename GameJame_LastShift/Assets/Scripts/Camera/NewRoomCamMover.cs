using System.Collections;
using UnityEngine;

public class NewRoomCamMover : MonoBehaviour
{

    public Camera cam;
    public Transform newRoomTransform;
    public float lerpDuration = 1;

    // If the player enters, teleport the camera to the new room
    // Make it smooth and not jarring?? lol
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(moveCamera());
        }
    }

    IEnumerator moveCamera()
    {
        float elapsedTime = 0;
        while (elapsedTime < lerpDuration)
        {
            float t = elapsedTime / lerpDuration; 
            cam.transform.position = Vector3.Lerp(cam.transform.position, newRoomTransform.position, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}