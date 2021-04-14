using TMPro;
using UnityEngine;

namespace UI
{
    public class InBetweenUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private TextMeshProUGUI sourceTitle;
        [SerializeField] private TextMeshProUGUI sourceURL;
        [SerializeField] private TextMeshProUGUI buttonText;

        private InBetweenScreenData _data;
        
        private void Awake()
        {
            _data = FindObjectOfType<InBetweenScreenData>();

            text.text = LocalizationHelper.Get(_data.text);
            sourceTitle.text = LocalizationHelper.Get(_data.sourceTitle);
            sourceURL.text = LocalizationHelper.Get(_data.sourceURL);
            buttonText.text = LocalizationHelper.Get("infoUI.ContinueButton");
        }

        public void OnContinueButtonClick()
        {
            ScreenFade.Instance.FadeToBlackThenLoadScene(_data.nextScene);
        }
    }
 }