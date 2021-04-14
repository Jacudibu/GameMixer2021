using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using ScriptableObjects;
using UI;
using UI.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;
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

        if (!LocalizationHelper.IsInitialized)
        {
            yield return InitializeLocalization();
        }

        LocalizationHelper.SetFriendFirstName(character.firstName);
        PhoneUI.Instance.Initialize(character);
        
        yield return DialogueManager.Instance.StartDialogueCoroutine(initialDialogue);
        
        LoadWebsite(posts);
    }

    private static IEnumerator InitializeLocalization()
    {
        // TODO: Move this somewhere else and listen to some LocalizationSettings.OnLocalizationChanged event, otherwise we do this on every scene load
        // (which in itself isn't too bad, just takes a couple frames)
        var localeOperation = LocalizationSettings.SelectedLocaleAsync;
        while (!localeOperation.IsDone)
        {
            yield return null;
        }

        var tableOperation = LocalizationSettings.StringDatabase.GetTableAsync("Strings", localeOperation.Result);
        while (!tableOperation.IsDone)
        {
            yield return null;
        }

        LocalizationHelper.Initialize(tableOperation.Result);
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