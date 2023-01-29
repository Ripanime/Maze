using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderScene : MonoBehaviour
{
    [SerializeField] private string sceneName;
    public void LoadScene() 
    {
        SceneManager.LoadScene(sceneName);
    }
}
