using Localization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private int firstLevelIndex;
    [SerializeField] private TextMeshProUGUI collaborationHeader;
    [SerializeField] private TextMeshProUGUI creditsHeader;

    private void Awake()
    {
        Localization.Localization.Initialize("");
        UpdateLocalization(Application.systemLanguage == SystemLanguage.German 
            ? Language.German 
            : Language.English);
    }

    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene(firstLevelIndex);
    }
    
    public void OnGermanSelected()
    {
        AudioManager.Instance.PlayLoginButtonSound();
        UpdateLocalization(Language.German);
    }

    public void OnEnglishSelected()
    {
        AudioManager.Instance.PlayLoginButtonSound();
        UpdateLocalization(Language.English);
    }

    private void UpdateLocalization(Language language)
    {
        Localization.Localization.SetLanguage(language);
        collaborationHeader.text = Localization.Localization.Get("startUI.CollaborationHeader");
        creditsHeader.text = Localization.Localization.Get("startUI.CreditHeader");
    }
}
