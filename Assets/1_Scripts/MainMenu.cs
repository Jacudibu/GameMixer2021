using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private SceneAsset firstLevel;
    
    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene(firstLevel.name);
    }
}
