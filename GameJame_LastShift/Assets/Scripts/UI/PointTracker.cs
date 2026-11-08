using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PointTracker : MonoBehaviour
{
    public int pointsToWin = 3;
    private int points;
    private int failureCount;

    void Update()
    {
        if (points >= pointsToWin && failureCount == 0)
        {
            StartCoroutine(WaitOne());
        }
        else if (points >= pointsToWin && failureCount == pointsToWin)
        {
            StartCoroutine(WaitThree());
            SceneManager.LoadScene(3);
        }
        else if (points >= pointsToWin && failureCount > 0)
        {
            StartCoroutine(WaitTwo());
            SceneManager.LoadScene(2);
        }
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

    IEnumerator WaitOne()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
        IEnumerator WaitTwo()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }
        IEnumerator WaitThree()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(3);
    }
}
