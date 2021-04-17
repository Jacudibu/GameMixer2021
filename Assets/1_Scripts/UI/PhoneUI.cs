using System;
using Enums;
using JetBrains.Annotations;
using ScriptableObjects;
using UI.Elements;
using UnityEngine;
using Utility;

namespace UI
{
    public class PhoneUI : SingletonBehaviour<PhoneUI>
    {
        [SerializeField] private PhoneOpenUI openUI;
        [SerializeField] private PhoneClosedUI closedUI;

        private bool _isOpen;

        public void Open()
        {
            _isOpen = true;
            RefreshUI();
            closedUI.ResetNotificationCount();
            AudioManager.Instance.PlayPhoneOpenSound();
        }

        public void Close()
        {
            _isOpen = false;
            RefreshUI();
            AudioManager.Instance.PlayPhoneCloseSound();
        }

        private void RefreshUI()
        {
            openUI.gameObject.SetActive(_isOpen);
            closedUI.gameObject.SetActive(!_isOpen);
        }
        
        private void Awake()
        {
            _isOpen = false;
            RefreshUI();
        }
        
        public void Initialize([NotNull] CharacterObject character)
        {
            openUI.Initialize(character);
        }

        public void SetResponseButton(string text, [NotNull] Action onResponseButtonClick)
        {
            openUI.SetResponseButton(text, onResponseButtonClick);
        }

        public void OnResponseButtonClick()
        {
            openUI.OnResponseButtonClick();
        }

        public void ShowFriendIsTyping()
        {
            openUI.SetFriendIsTyping(true);
        }

        public void PostMessage([NotNull] DialogueElement message)
        {
            openUI.PostMessage(message);
            if (!_isOpen)
            {
                closedUI.IncreaseNotificationCount();
                AudioManager.Instance.PlayPhoneNotificationSound();
            }
            else
            {
                if (message.alignment == HorizontalPosition.Left)
                {
                    AudioManager.Instance.PlayPhoneOpenMessageReceivedSound();
                }
                else
                {
                    AudioManager.Instance.PlayPhoneOpenMessageSentSound();
                }
            }
        }
        
        public void Clear()
        {
            openUI.Clear();
            closedUI.ResetNotificationCount();
        }
    }
}
