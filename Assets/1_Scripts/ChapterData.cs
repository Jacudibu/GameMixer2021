using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using ScriptableObjects;
using UI;
using UI.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterData : MonoBehaviour
{
    [SerializeField] private CharacterObject character;
    [SerializeField] private DialogueObject initialDialogue;
    [SerializeField] private DialogueObject successDialogue;

    public string[] validAccountNames;
    public string[] validPasswords;
    
    private void Awake()
    {
        MainUI.Instance.gameObject.SetActive(false);
    }

    public void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        StartCoroutine(InitializeCoroutine());
    }

    private IEnumerator InitializeCoroutine()
    {
        var posts = Resources.LoadAll<PostObject>("Posts/" + SceneManager.GetActiveScene().name);
        if (posts.Length == 0) 
        {
            Debug.LogError("Cannot Load Posts! You'll need to create some for this chapter first and put them into the respective Posts folder.\n" +
                           "If you want to load posts, make sure they are in a Resource folder with the same name as the scene.");
        }

        Localization.Localization.Initialize(character.firstName);
        LocalizePasswords();
        PhoneUI.Instance.Initialize(character);
        
        yield return DialogueManager.Instance.StartDialogueCoroutine(initialDialogue);
        
        LoadWebsite(posts);
    }

    private void LocalizePasswords()
    {
        for (var i = 0; i < validPasswords.Length; i++)
        {
            validPasswords[i] = Localization.Localization.Get(validPasswords[i]);
        }
    }

    private void LoadWebsite([NotNull] IEnumerable<PostObject> posts)
    {
        MainUI.Instance.gameObject.SetActive(true);
        MainUI.Instance.Initialize(character);
        PostCollection.Instance.Initialize(posts);
    }

    public void OnSuccessfulLogin()
    {
        if (successDialogue != null)
        {
            DialogueManager.Instance.StartDialogue(successDialogue);
        }
    }
}