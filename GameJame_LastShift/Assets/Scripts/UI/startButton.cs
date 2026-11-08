using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneChanger : MonoBehaviour
{
    public void LoadGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
