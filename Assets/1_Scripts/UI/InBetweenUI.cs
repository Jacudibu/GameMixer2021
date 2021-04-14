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

            text.text = Localization.Localization.Get(_data.text);
            sourceTitle.text = Localization.Localization.Get(_data.sourceTitle);
            sourceURL.text = Localization.Localization.Get(_data.sourceURL);
            buttonText.text = Localization.Localization.Get("infoUI.ContinueButton");
        }

        public void OnContinueButtonClick()
        {
            ScreenFade.Instance.FadeToBlackThenLoadScene(_data.nextScene);
        }
    }
 }