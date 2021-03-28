using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
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
    private bool _showNextDialogueElement;
    
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

    private void ShowNextDialogue()
    {
        _showNextDialogueElement = true;
    }
    
    private IEnumerator InitializeCoroutine()
    {
        var posts = Resources.LoadAll<PostObject>(SceneManager.GetActiveScene().name);
        if (posts.Length == 0) 
        {
            Debug.LogError("Cannot Load Posts! Unable to find a matching Resource folder for current scene.\n" +
                           "If you want to load posts, make sure they are in a Resource folder with the same name as the scene.");
        }

        yield return InitializeLocalization();

        PhoneUI.Instance.Initialize(character);
        
        // TODO: This is only here for testing, will be moved somewhere else later on to allow multiple dialogues per chapter
        foreach (var element in initialDialogue.elements)
        {
            if (element.sentManually)
            {
                PhoneUI.Instance.SetResponseButton(element.text, ShowNextDialogue);
                while (!_showNextDialogueElement)
                {
                    yield return null;
                }
                _showNextDialogueElement = false;
            }
            else
            {
                var waitTime = Math.Max(0.5f, element.text.Length / 75f);
                waitTime = Math.Min(waitTime, 2.5f); // qq Math.Clamp wasn't there before .Net Standard 2.1

                if (element.alignment == HorizontalPosition.Left)
                {
                    PhoneUI.Instance.ShowFriendIsTyping(true);
                }
                
                yield return new WaitForSeconds(waitTime);
            }
            
            PhoneUI.Instance.PostMessage(element);
            yield return null;
        }
        
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
}