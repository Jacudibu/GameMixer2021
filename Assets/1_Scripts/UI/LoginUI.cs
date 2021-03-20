using System;
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

        private const string CredentialName = "bla";
        private const string CredentialPassword = "blub";
        
        public void Login()
        {
            Debug.Log("Logging in with " + nameInput.text + " | " + passwordInput.text);

            if (!nameInput.text.ToLower().Equals(CredentialName.ToLower()))
            {
                // TODO: Display account not found
                Debug.Log("Account not found!");
                return;
            }
            
            if (!passwordInput.text.ToLower().Equals(CredentialPassword.ToLower()))
            {
                // TODO: Display password does not match
                Debug.Log("Password does not match!");
                return;
            }

            inputParent.SetActive(false);
            successParent.SetActive(true);
        }

        private void OnEnable()
        {
            nameInput.text = "";
            passwordInput.text = "";
            
            inputParent.SetActive(true);
            successParent.SetActive(false);
        }
    }
}
