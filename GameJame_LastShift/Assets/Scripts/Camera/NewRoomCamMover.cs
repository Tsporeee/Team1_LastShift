using System.Collections;
using UnityEngine;

public class NewRoomCamMover : MonoBehaviour
{

    public Camera cam;
    public Transform newRoomTransform;
    public Transform oldRoomTransform;
    public GameObject player;
    private bool passed = false;
    private float lerpDuration = 1;
    
    // If the player enters, teleport the camera to the new room
    // Make it smooth and not jarring?? lol
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !passed)
        {
            passed = true;
            StartCoroutine(moveCamera());
        }
        else if (other.CompareTag("Player") && passed)
        {   
            passed = false;
            StartCoroutine(moveCameraBack());
        }
    }

    IEnumerator moveCamera()
    {
        Vector3 positionThisFrame = cam.transform.position; 
        player.transform.position = new Vector3(player.transform.position.x + 0.75f, player.transform.position.y, player.transform.position.z);
        for (float t = 0; t <= lerpDuration; t += Time.deltaTime)
        {
            cam.transform.position = Vector3.Lerp (positionThisFrame, newRoomTransform.position, t / lerpDuration);

            // wait until the next frame
            yield return null;
        }
    }

    IEnumerator moveCameraBack()
    {
        Vector3 positionThisFrame = cam.transform.position; 
        player.transform.position = new Vector3(player.transform.position.x - 0.75f, player.transform.position.y, player.transform.position.z);
        for (float t = 0; t <= lerpDuration; t += Time.deltaTime)
        {
            cam.transform.position = Vector3.Lerp (positionThisFrame, oldRoomTransform.position, t / lerpDuration);

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