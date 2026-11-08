using System.Collections;
using UnityEngine;

public class NewRoomCamMover : MonoBehaviour
{

    public Camera cam;
    public Transform newRoomTransform;
    private float lerpDuration = 1;
    Coroutine _currentMovement = null;

    // If the player enters, teleport the camera to the new room
    // Make it smooth and not jarring?? lol
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
             if(_currentMovement != null)
        {
            StopCoroutine(moveCamera());
        }
            StartCoroutine(moveCamera());
        }
    }

    IEnumerator moveCamera()
    {
        Vector3 positionThisFrame = cam.transform.position; 
        for (float t = 0; t <= lerpDuration; t += Time.deltaTime)
        {
            cam.transform.position = Vector3.Lerp (positionThisFrame, newRoomTransform.position, t / lerpDuration);

            // wait until the next frame
            yield return null;
        }
    }
}


        // while (elapsedTime < lerpDuration)
        // {
        //     Vector3 startPosition = cam.transform.position;
        //     float t = elapsedTime / lerpDuration; 
        //     cam.transform.position = Vector3.Lerp(startPosition, endPosition, t);
        //     elapsedTime += Time.deltaTime;
        //     yield return null;
        // }