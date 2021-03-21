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
        [SerializeField] private TextMeshProUGUI dateOfBirthText;
        [SerializeField] private TextMeshProUGUI locationText;
        [SerializeField] private TextMeshProUGUI hobbiesText;

        public void Initialize([NotNull] CharacterObject character)
        {
            profileImage.sprite = character.profilePicture;
            nameText.text = character.firstName + " " + character.lastName;
            dateOfBirthText.text = character.dayOfBirth + " / " + character.monthOfBirth + " / " + character.yearOfBirth;
            locationText.text = character.location;
            hobbiesText.text = string.Join("\n", character.hobbies);
        }
    }
}
