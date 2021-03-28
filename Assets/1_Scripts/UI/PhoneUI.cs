using System;
using System.Collections;
using Enums;
using JetBrains.Annotations;
using ScriptableObjects;
using TMPro;
using UI.Elements;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UI
{
    public class PhoneUI : SingletonBehaviour<PhoneUI>
    {
        [SerializeField] private GameObject leftAlignedPrefab;
        [SerializeField] private GameObject rightAlignedPrefab;
        [Space(10)]
        [SerializeField] private Transform contentParent;
        [SerializeField] private Button responseButton;
        [SerializeField] private TextMeshProUGUI friendIsTyping;
        [Space(10)]
        [SerializeField] private Image friendProfileImage;
        [SerializeField] private TextMeshProUGUI friendName;
        [Space(10)]
        [SerializeField] private GameObject openUI;
        [SerializeField] private PhoneClosedUI closedUI;        
        
        private TextMeshProUGUI _responseButtonText;
        private ScrollRect _scrollRect;

        private Coroutine _scrollRoutine;
        private float autoScrollSpeed = 5;

        private Action _onResponseButtonClicked;

        private bool _isOpen;

        public void Open()
        {
            _isOpen = true;
            RefreshUI();
            ScrollDown();
            closedUI.ResetNotificationCount();
        }

        public void Close()
        {
            _isOpen = false;
            RefreshUI();
        }

        private void RefreshUI()
        {
            openUI.gameObject.SetActive(_isOpen);
            closedUI.gameObject.SetActive(!_isOpen);
        }
        
        private void Awake()
        {
            _scrollRect = GetComponentInChildren<ScrollRect>();
            _responseButtonText = responseButton.GetComponentInChildren<TextMeshProUGUI>();
            responseButton.gameObject.SetActive(false);
            Close();
        }

        public void Initialize([NotNull] CharacterObject character)
        {
            friendProfileImage.sprite = character.profilePicture;
            friendName.text = character.GetNameString();
            friendIsTyping.text = LocalizationHelper.Get("phoneUI.IsTyping");
        }

        public void SetResponseButton(string text, [NotNull] Action onResponseButtonClick) // TODO: Add on click here
        {
            _onResponseButtonClicked = onResponseButtonClick;
            _responseButtonText.text = text;
            responseButton.gameObject.SetActive(true);
        }

        public void OnResponseButtonClick()
        {
            responseButton.gameObject.SetActive(false);
            var lastAction = _onResponseButtonClicked;
            _onResponseButtonClicked = null;
            lastAction.Invoke();
        }

        public void ShowFriendIsTyping(bool value)
        {
            friendIsTyping.gameObject.SetActive(value);
        }

        public void PostMessage([NotNull] DialogueElement message)
        {
            ShowFriendIsTyping(false);
            
            var prefab = message.alignment == HorizontalPosition.Left
                ? leftAlignedPrefab
                : rightAlignedPrefab;
            
            var instance = Instantiate(prefab, contentParent);
            instance.GetComponentInChildren<TextMeshProUGUI>().text = LocalizationHelper.Get(message.text);

            if (_isOpen)
            {
                ScrollDown();
            }
            else
            {
                closedUI.IncreaseNotificationCount();
            }
        }

        private void ScrollDown()
        {
            if (_scrollRoutine != null)
            {
                StopCoroutine(_scrollRoutine);
            }
            _scrollRoutine = StartCoroutine(ScrollDownCoroutine());
        }
        
        private IEnumerator ScrollDownCoroutine()
        {
            yield return new WaitForEndOfFrame();
            var origin = _scrollRect.verticalNormalizedPosition;
            for (var i = 0f; i < 1; i += Time.deltaTime * autoScrollSpeed)
            {
                _scrollRect.verticalNormalizedPosition = Mathf.Lerp(origin, 0, i);
                yield return new WaitForEndOfFrame();
            }
            _scrollRect.verticalNormalizedPosition = 0;
        }

        public void Clear()
        {
            contentParent.DeleteAllChildren();
        }
    }
}
