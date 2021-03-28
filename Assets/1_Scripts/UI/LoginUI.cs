using ScriptableObjects;
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
        [SerializeField] private DialogueObject successDialogue;

        
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

            if (successDialogue != null)
            {
                DialogueManager.Instance.StartDialogue(successDialogue);
                closeButton.gameObject.SetActive(false);
            }
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
