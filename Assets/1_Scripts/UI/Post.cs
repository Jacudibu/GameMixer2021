using JetBrains.Annotations;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Post : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI text;
        
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
            
            // TODO: Comments and stuff
        }
    }
}