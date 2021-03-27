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
        var posts = Resources.LoadAll<PostObject>(SceneManager.GetActiveScene().name);
        if (posts.Length == 0) 
        {
            Debug.LogError("Cannot Load Posts! Unable to find a matching Resource folder for current scene.\n" +
                           "If you want to load posts, make sure they are in a Resource folder with the same name as the scene.");
        }

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
        
        foreach (var element in initialDialogue.elements)
        {
            PhoneUI.Instance.PostMessage(element);
            yield return new WaitForSeconds(1);
        }
        
        LoadWebsite(posts);
    }

    private void LoadWebsite([NotNull] IEnumerable<PostObject> posts)
    {
        MainUI.Instance.gameObject.SetActive(true);
        MainUI.Instance.Initialize(character);
        PostCollection.Instance.Initialize(posts);
    }
}