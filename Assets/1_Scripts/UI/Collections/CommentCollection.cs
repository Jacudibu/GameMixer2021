using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using ScriptableObjects;
using UI.Elements;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UI.Collections
{
    public class CommentCollection : MonoBehaviour
    {
        [SerializeField] private GameObject commentPrefab;
        
        public void Initialize([NotNull] IEnumerable<CommentObject> comments)
        {
            transform.DeleteAllChildren();

            foreach (var comment in comments)
            {
                var instance = Instantiate(commentPrefab, transform);
                var script = instance.GetComponent<Comment>();
                script.Initialize(comment);
            }
        }
    }
}