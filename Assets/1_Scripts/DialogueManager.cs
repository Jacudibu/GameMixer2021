using System;
using System.Collections;
using Enums;
using JetBrains.Annotations;
using ScriptableObjects;
using UI;
using UnityEngine;
using Utility;

public class DialogueManager : SingletonBehaviour<DialogueManager>
{
    [SerializeField] private bool skipDialogue;

    private bool _advanceDialogue;
    [CanBeNull] private Coroutine _currentDialogueCoroutine;
    
    private void AdvanceDialogue()
    {
        _advanceDialogue = true;
    }
    
    public void StartDialogue([NotNull] DialogueObject dialogue, float initialDelay = 0, bool clearPreExistingDialogue = false)
    {
        if (_currentDialogueCoroutine != null)
        {
            StopCoroutine(_currentDialogueCoroutine);
        }

        if (clearPreExistingDialogue)
        {
            PhoneUI.Instance.Clear();
        }

        _currentDialogueCoroutine = StartCoroutine(PrintDialogueCoroutine(dialogue, initialDelay));
    }

    public IEnumerator StartDialogueCoroutine([NotNull] DialogueObject dialogue, float initialDelay = 0, bool clearPreExistingDialogue = false)
    {
        StartDialogue(dialogue, initialDelay, clearPreExistingDialogue);

        while (_currentDialogueCoroutine != null && !skipDialogue)
        {
            yield return new WaitForSeconds(1);
        }
    }

    private IEnumerator PrintDialogueCoroutine([NotNull] DialogueObject dialogue, float initialDelay)
    {
        if (initialDelay > 0 && !skipDialogue)
        {
            yield return new WaitForSeconds(initialDelay);
        }
        
        foreach (var element in dialogue.elements)
        {
            if (element.sentManually)
            {
                PhoneUI.Instance.SetResponseButton(element.text, AdvanceDialogue);
                while (!_advanceDialogue && !skipDialogue)
                {
                    yield return null;
                }
                _advanceDialogue = false;
            }
            else
            {
                var waitTime = Math.Max(0.5f, element.text.Length / 75f);
                waitTime = Math.Min(waitTime, 2.5f); // qq Math.Clamp wasn't there before .Net Standard 2.1

                if (element.alignment == HorizontalPosition.Left)
                {
                    PhoneUI.Instance.ShowFriendIsTyping();
                }

                if (!skipDialogue)
                {
                    yield return new WaitForSeconds(waitTime);
                }
            }
            
            PhoneUI.Instance.PostMessage(element);
            yield return null;
        }

        _currentDialogueCoroutine = null;
    }
}