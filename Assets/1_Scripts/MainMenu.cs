using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Object firstLevel;
    [SerializeField] private GameObject localizationButtons;
    [SerializeField] private GameObject organizerLogos;
    [SerializeField] private GameObject mainInterface;
    [SerializeField] private GameObject creditsScreen;

    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene(firstLevel.name);
    }
    
    
    public void OnLanguageSelected()
    {
        Debug.Log("You selected a language and can now access the main menu");
        localizationButtons.SetActive(false);
        organizerLogos.SetActive(false);
        mainInterface.SetActive(true);
    }
    public void OnCreditsSelected()
    {
        Debug.Log("Credits Opened");
        mainInterface.SetActive(false);
        creditsScreen.SetActive(true);
    }
    public void OnBackSelected()
    {
        Debug.Log("Credits Closed");
        creditsScreen.SetActive(false);
        mainInterface.SetActive(true);
    }
    public void OnChangeLanguageSelected()
    {
        Debug.Log("Back to Languages (inverted languages in localization)");
        mainInterface.SetActive(false);
        organizerLogos.SetActive(true);
        localizationButtons.SetActive(true);
    }
    public void OnQuitPressed()
    {
        Debug.Log("You pressed Quit!");
        Application.Quit();
    }
}
