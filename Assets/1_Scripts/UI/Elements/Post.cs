using JetBrains.Annotations;
using ScriptableObjects;
using TMPro;
using UI.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Elements
{
    public class Post : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI text;

        [SerializeField] private Image headerImage;
        [SerializeField] private TextMeshProUGUI headerName;
        [SerializeField] private TextMeshProUGUI headerTimestamp;
        
        private CommentCollection _commentCollection;
        
        public void Initialize([NotNull] PostObject post)
        {
            headerImage.sprite = post.character.profilePicture;
            headerName.text = post.character.GetNameString();
            headerTimestamp.text = post.GetTimestampString();
            
            if (post.image != null)
            {
                image.sprite = post.image;
            }
            else
            {
                Destroy(image.gameObject);
            }
            
            text.text = LocalizationHelper.Get(post.text);

            _commentCollection = GetComponentInChildren<CommentCollection>();
            if (post.comments.Length == 0)
            {
                Destroy(_commentCollection.gameObject);
            }
            else
            {
                _commentCollection.Initialize(post.comments);
            }
        }
    }
}