using JetBrains.Annotations;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Elements
{
    public class Comment : MonoBehaviour
    {
        [SerializeField] private Image characterPicture;
        [SerializeField] private TextMeshProUGUI characterName;
        [SerializeField] private TextMeshProUGUI timeStamp;
        [SerializeField] private TextMeshProUGUI text;
        
        public void Initialize([NotNull] CommentObject comment)
        {
            characterPicture.sprite = comment.character.profilePicture;
            characterName.text = comment.character.firstName + " " + comment.character.lastName;
            timeStamp.text = comment.day + "/" + comment.month + "/" + comment.year.ToString("0000") + " – " + comment.hour.ToString("00") + ":" + comment.minutes.ToString("00");
            text.text = comment.text;
        }
    }
}