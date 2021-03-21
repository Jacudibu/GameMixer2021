using ScriptableObjects;
using UI.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterData : MonoBehaviour
{
    [SerializeField] private CharacterObject character;
    
    public void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        var posts = Resources.LoadAll<PostObject>(SceneManager.GetActiveScene().name);
        if (posts.Length == 0) 
        {
            Debug.LogError("Cannot Load Posts! Unable to find a matching Resource folder for current scene.\n" +
                           "If you want to load posts, make sure they are in a Resource folder with the same name as the scene.");
        }
        
        UI.MainUI.Instance.Initialize(character);
        PostCollection.Instance.Initialize(posts);
    }
}