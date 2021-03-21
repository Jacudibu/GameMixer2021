using ScriptableObjects;
using UnityEngine;

// TODO: Make Chapters completely addressable as Scriptable Objects
public class ChapterData : MonoBehaviour
{
    [SerializeField] private CharacterObject character;

    // TODO: We can just use Addressable assets here, so new posts can be added through the file system alone
    [SerializeField] private PostObject[] posts;
    
    public void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        UI.MainUI.Instance.Initialize(character);
        UI.PostCollection.Instance.Initialize(posts);
    }
}