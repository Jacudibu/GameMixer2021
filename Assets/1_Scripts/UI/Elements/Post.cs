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
        private CommentCollection _commentCollection;
        
        public void Initialize([NotNull] PostObject post)
        {
            if (post.image != null)
            {
                image.sprite = post.image;
            }
            else
            {
                Destroy(image.gameObject);
            }
            
            text.text = post.text;

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