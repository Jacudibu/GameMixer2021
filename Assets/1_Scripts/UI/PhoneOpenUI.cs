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
    public class PhoneOpenUI : MonoBehaviour
    {
        [SerializeField] private GameObject leftAlignedPrefab;
        [SerializeField] private GameObject rightAlignedPrefab;
        [Space(10)]
        [SerializeField] private Transform contentParent;
        [SerializeField] private Button responseButton;
        [SerializeField] private TextMeshProUGUI responseButtonText;
        [SerializeField] private TextMeshProUGUI friendIsTyping;
        [Space(10)]
        [SerializeField] private Image friendProfileImage;
        [SerializeField] private TextMeshProUGUI friendName;
        [Space(10)]        
        [SerializeField] float autoScrollSpeed = 5;

        private Coroutine _scrollRoutine;
                
        private ScrollRect _scrollRect;

        private Action _onResponseButtonClicked;

        private void Awake()
        {
            _scrollRect = GetComponentInChildren<ScrollRect>();
        }
        
        private void OnEnable()
        {
            ScrollDown();
            responseButton.gameObject.SetActive(_onResponseButtonClicked != null);
        }

        public void Initialize([NotNull] CharacterObject character)
        {
            friendProfileImage.sprite = character.profilePicture;
            friendName.text = character.GetNameString();
            friendIsTyping.text = LocalizationHelper.Get("phoneUI.IsTyping");
        }

        public void SetResponseButton(string text, [NotNull] Action onResponseButtonClick)
        {
            _onResponseButtonClicked = onResponseButtonClick;
            responseButtonText.text = LocalizationHelper.Get(text);
            if (responseButtonText.text.Length > 40)
            {
                responseButtonText.text = responseButtonText.text.Substring(0, 37) + "...";
            }
            responseButton.gameObject.SetActive(true);
        }

        public void OnResponseButtonClick()
        {
            AudioManager.Instance.PlayPhoneResponseButtonSound();
            responseButton.gameObject.SetActive(false);
            var lastAction = _onResponseButtonClicked;
            _onResponseButtonClicked = null;
            lastAction.Invoke();
        }

        public void SetFriendIsTyping(bool value)
        {
            friendIsTyping.gameObject.SetActive(value);
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
        
        public void PostMessage([NotNull] DialogueElement message)
        {
            SetFriendIsTyping(false);
            
            var prefab = message.alignment == HorizontalPosition.Left
                ? leftAlignedPrefab
                : rightAlignedPrefab;
            
            var instance = Instantiate(prefab, contentParent);
            instance.GetComponentInChildren<TextMeshProUGUI>().text = LocalizationHelper.Get(message.text);

            if (isActiveAndEnabled)
            {
                ScrollDown();
            }
        }
    }
}