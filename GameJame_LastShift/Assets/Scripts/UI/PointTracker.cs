using UnityEngine;

public class PointTracker : MonoBehaviour
{
    public int pointsToWin = 3;
    private int points;
    private int failureCount;

    void Update()
    {
        
    }

    public void incrementPoints()
    {
        points++;
        Debug.Log("plus one point goat");
    }

    public void incrementFailureCount()
    {
        failureCount++;
        Debug.Log("u messed up big bro");
    }
}
