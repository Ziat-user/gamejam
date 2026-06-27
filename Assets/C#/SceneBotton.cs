using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBotton : MonoBehaviour
{
    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
