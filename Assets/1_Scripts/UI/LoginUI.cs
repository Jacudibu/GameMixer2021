using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LoginUI : MonoBehaviour
    {
        [SerializeField] private Button closeButton;
        [SerializeField] private TMP_InputField nameInput;
        [SerializeField] private TMP_InputField passwordInput;

        [SerializeField] private GameObject inputParent;
        [SerializeField] private GameObject successParent;

        [SerializeField] private TextMeshProUGUI errorMessage;

        private ChapterData _chapterData;

        private void Start()
        {
            _chapterData = FindObjectOfType<ChapterData>();
        }

        public void Login()
        {
            if (_chapterData.validAccountNames.All(x => !x.ToLower().Equals(nameInput.text.ToLower().Trim())))
            {
                HandleError("Account not found!");
                return;
            }
            
            if (_chapterData.validPasswords.All(x => !x.ToLower().Equals(passwordInput.text.ToLower().Trim())))
            {
                HandleError("Password does not match!");
                return;
            }

            AudioManager.Instance.PlaySuccessfulLoginSound();
            inputParent.SetActive(false);
            successParent.SetActive(true);

            _chapterData.OnSuccessfulLogin();
        }

        private void HandleError(string message)
        {
            AudioManager.Instance.PlayWrongLonginSound();
            errorMessage.text = message;
        }

        private void OnEnable()
        {
            errorMessage.text = "";
            nameInput.text = "";
            passwordInput.text = "";
            
            inputParent.SetActive(true);
            successParent.SetActive(false);
            
            AudioManager.Instance.PlayLoginButtonSound();
        }
    }
}
