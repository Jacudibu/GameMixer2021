using System.Linq;
using TMPro;
using UnityEngine;

namespace UI
{
    public class LoginUI : MonoBehaviour
    {
        [SerializeField] private GameObject loginButton;
        [SerializeField] private TMP_InputField nameInput;
        [SerializeField] private TMP_InputField passwordInput;

        [SerializeField] private GameObject inputParent;
        [SerializeField] private GameObject successParent;

        [SerializeField] private TextMeshProUGUI errorMessage;

        
        [SerializeField] private TextMeshProUGUI successText;
        [SerializeField] private TextMeshProUGUI loginButtonText;

        
        private bool _wasAccountNameCorrectAtLeastOnce;
        private ChapterData _chapterData;

        private void Awake()
        {
            _chapterData = FindObjectOfType<ChapterData>();
            nameInput.placeholder.GetComponent<TextMeshProUGUI>().text = Localization.Localization.Get("loginUI.Account");
            passwordInput.placeholder.GetComponent<TextMeshProUGUI>().text = Localization.Localization.Get("loginUI.Password");
            successText.text = Localization.Localization.Get("loginUI.Success");
            loginButtonText.text = Localization.Localization.Get("loginUI.Login");
        }

        public void Login()
        {
            if (_chapterData.validAccountNames.All(x => !x.ToLower().Equals(nameInput.text.ToLower().Trim())))
            {
                HandleError(Localization.Localization.Get("loginUI.WrongAccount"));
                return;
            }

            _wasAccountNameCorrectAtLeastOnce = true;
            nameInput.readOnly = true;
            nameInput.interactable = false;
            
            if (_chapterData.validPasswords.All(x => !x.ToLower().Equals(passwordInput.text.ToLower().Trim())))
            {
                HandleError(Localization.Localization.Get("loginUI.WrongPassword"));
                return;
            }

            AudioManager.Instance.PlaySuccessfulLoginSound();
            inputParent.SetActive(false);
            successParent.SetActive(true);

            _chapterData.OnSuccessfulLogin();
            loginButton.SetActive(false);
        }

        private void HandleError(string message)
        {
            AudioManager.Instance.PlayWrongLonginSound();
            errorMessage.text = message;
        }

        private void OnEnable()
        {
            errorMessage.text = "";
            if (!_wasAccountNameCorrectAtLeastOnce)
            {
                nameInput.text = "";
            }
            passwordInput.text = "";
            
            inputParent.SetActive(true);
            successParent.SetActive(false);
            
            AudioManager.Instance.PlayLoginButtonSound();
        }
    }
}
