using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterKeySceneChanger : MonoBehaviour
{
    [SerializeField]
    private string sceneName;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}