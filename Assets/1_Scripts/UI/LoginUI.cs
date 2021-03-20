using TMPro;
using UnityEngine;

namespace UI
{
    public class LoginUI : MonoBehaviour
    {
        [SerializeField] private TMP_InputField nameInput;
        [SerializeField] private TMP_InputField passwordInput;

        public void Login()
        {
            Debug.Log("Logging in with " + nameInput.text + " | " + passwordInput.text);
        }
    }
}
