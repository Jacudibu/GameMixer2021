using System.Linq;
using JetBrains.Annotations;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UI
{
    public class MainUI : SingletonBehaviour<MainUI>
    {
        [SerializeField] private TextMeshProUGUI nameText;

        [SerializeField] private Image profileImage;
        [SerializeField] private TextMeshProUGUI aboutMeHeaderText;
        [SerializeField] private TextMeshProUGUI dateOfBirthHeaderText;
        [SerializeField] private TextMeshProUGUI dateOfBirthText;
        [SerializeField] private TextMeshProUGUI locationHeaderText;
        [SerializeField] private TextMeshProUGUI locationText;
        [SerializeField] private TextMeshProUGUI mailText;
        [SerializeField] private TextMeshProUGUI hobbiesText;
        
        [SerializeField] private TextMeshProUGUI loginButtonText;

        public void Initialize([NotNull] CharacterObject character)
        {
            profileImage.sprite = character.profilePicture;
            nameText.text = character.GetNameString();

            aboutMeHeaderText.text = Localization.Localization.Get("aboutMe.Title");
            dateOfBirthHeaderText.text = "<sprite=0>" + Localization.Localization.Get("aboutMe.Birthday");
            locationHeaderText.text = "<sprite=0>" + Localization.Localization.Get("aboutMe.Location");
            loginButtonText.text = Localization.Localization.Get("loginUI.Login");

            dateOfBirthText.text = character.dayOfBirth + " / " + character.monthOfBirth + " / " + character.yearOfBirth;
            locationText.text = Localization.Localization.Get(character.location);
            mailText.text = Localization.Localization.Get(character.email);
            hobbiesText.text = string.Join("\n", character.hobbies.Select(Localization.Localization.Get));
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
