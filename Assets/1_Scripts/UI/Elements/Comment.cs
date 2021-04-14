using JetBrains.Annotations;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI.Elements
{
    public class Comment : CommentBase
    {
        [SerializeField] private TextMeshProUGUI timeStamp;
        [FormerlySerializedAs("subCommentParent")] [SerializeField] private RectTransform responseCommentParent;
        [FormerlySerializedAs("subCommentPrefab")] [SerializeField] private GameObject responseCommentPrefab;
        
        public void Initialize([NotNull] CommentObject comment)
        {
            characterPicture.sprite = comment.character.profilePicture;
            characterName.text = comment.character.GetNameString();
            text.text = Localization.Localization.Get(comment.text);

            if (comment.responseComments.Count == 0)
            {
                Destroy(responseCommentParent.gameObject);
            }
            else
            {
                foreach (var subComment in comment.responseComments)
                {
                    var instance = GameObject.Instantiate(responseCommentPrefab, responseCommentParent);
                    var sub = instance.GetComponent<CommentResponse>();
                    sub.Initialize(subComment);
                }    
            }
        }
    }
}