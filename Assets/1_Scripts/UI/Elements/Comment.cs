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
            characterName.text = comment.character.GetNameString();
            timeStamp.text = comment.GetTimestampString();
            text.text = LocalizationHelper.Get(comment.text);
        }
    }
}