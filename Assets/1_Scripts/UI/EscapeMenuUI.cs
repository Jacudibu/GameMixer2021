using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class EscapeMenuUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI backToMainMenuButtonText;
        [SerializeField] private GameObject contentParent;
        
        private void Awake()
        {
            backToMainMenuButtonText.text = Localization.Localization.Get("escapePopup.backToMainMenu");
            contentParent.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                AudioManager.Instance.PlayPhoneOpenSound();
                contentParent.gameObject.SetActive(true);
            }
        }

        public void OnClose()
        {
            AudioManager.Instance.PlayLoginButtonSound();
            contentParent.SetActive(false);
        }

        public void OnBackToMainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}