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
    private bool _advanceDialogue;
    [CanBeNull] private Coroutine _currentDialogueCoroutine;
    
    private void AdvanceDialogue()
    {
        _advanceDialogue = true;
    }
    
    public void StartDialogue([NotNull] DialogueObject dialogue, bool clearPreExistingDialogue = false)
    {
        if (_currentDialogueCoroutine != null)
        {
            StopCoroutine(_currentDialogueCoroutine);
        }

        if (clearPreExistingDialogue)
        {
            PhoneUI.Instance.Clear();
        }

        _currentDialogueCoroutine = StartCoroutine(PrintDialogueCoroutine(dialogue));
    }

    private IEnumerator PrintDialogueCoroutine([NotNull] DialogueObject dialogue)
    {
        foreach (var element in dialogue.elements)
        {
            if (element.sentManually)
            {
                PhoneUI.Instance.SetResponseButton(element.text, AdvanceDialogue);
                while (!_advanceDialogue)
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
                    PhoneUI.Instance.ShowFriendIsTyping(true);
                }
                
                yield return new WaitForSeconds(waitTime);
            }
            
            PhoneUI.Instance.PostMessage(element);
            yield return null;
        }

        _currentDialogueCoroutine = null;
    }
}