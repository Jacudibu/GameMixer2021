using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Elements
{
    public abstract class CommentBase : MonoBehaviour
    {
        [SerializeField] protected Image characterPicture;
        [SerializeField] protected TextMeshProUGUI characterName;
        [SerializeField] protected TextMeshProUGUI text;
    }
}