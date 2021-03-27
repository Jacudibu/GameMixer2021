using TMPro;
using UnityEngine;

namespace UI
{
    public class LoginUI : MonoBehaviour
    {
        [SerializeField] private TMP_InputField nameInput;
        [SerializeField] private TMP_InputField passwordInput;

        [SerializeField] private GameObject inputParent;
        [SerializeField] private GameObject successParent;

        [SerializeField] private TextMeshProUGUI errorMessage;
        
        private const string CredentialName = "bla";
        private const string CredentialPassword = "blub";
        
        public void Login()
        {
            Debug.Log("Logging in with " + nameInput.text + " | " + passwordInput.text);

            if (!nameInput.text.ToLower().Trim().Equals(CredentialName.ToLower()))
            {
                errorMessage.text = "Account not found!";
                return;
            }
            
            if (!passwordInput.text.ToLower().Trim().Equals(CredentialPassword.ToLower()))
            {
                errorMessage.text = "Password does not match!";
                return;
            }

            inputParent.SetActive(false);
            successParent.SetActive(true);
        }

        private void OnEnable()
        {
            errorMessage.text = "";
            nameInput.text = "";
            passwordInput.text = "";
            
            inputParent.SetActive(true);
            successParent.SetActive(false);
        }
    }
}
