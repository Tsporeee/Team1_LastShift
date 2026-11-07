using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Camera cam;
    public Transform firstLocation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        {
            cam.transform.position = firstLocation.transform.position;
        }
    }
}
