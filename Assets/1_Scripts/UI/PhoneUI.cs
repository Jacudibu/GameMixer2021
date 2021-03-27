using System;
using System.Collections;
using Enums;
using JetBrains.Annotations;
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

        [SerializeField] private Transform contentParent;
        [SerializeField] private Button responseButton;
        private TextMeshProUGUI _responseButtonText;
        
        private ScrollRect _scrollRect;

        private Coroutine _scrollRoutine;
        private float autoScrollSpeed = 5;

        private Action _onResponseButtonClicked;
        
        private void Awake()
        {
            _scrollRect = GetComponentInChildren<ScrollRect>();
            _responseButtonText = responseButton.GetComponentInChildren<TextMeshProUGUI>();
            responseButton.gameObject.SetActive(false);
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
        
        public void PostMessage([NotNull] DialogueElement message)
        {
            var prefab = message.alignment == HorizontalPosition.Left
                ? leftAlignedPrefab
                : rightAlignedPrefab;
            
            var instance = Instantiate(prefab, contentParent);
            instance.GetComponentInChildren<TextMeshProUGUI>().text = LocalizationHelper.Get(message.text);

            if (_scrollRoutine != null)
            {
                StopCoroutine(_scrollRoutine);
            }
            _scrollRoutine = StartCoroutine(ScrollDown());
        }

        private IEnumerator ScrollDown()
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
