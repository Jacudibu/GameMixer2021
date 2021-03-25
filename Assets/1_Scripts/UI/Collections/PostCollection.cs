using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using ScriptableObjects;
using UI.Elements;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Utility;

namespace UI.Collections
{
    public class PostCollection : SingletonBehaviour<PostCollection>
    {
        [FormerlySerializedAs("postWithPicture")] [SerializeField] private GameObject postPrefab;

        public void Initialize([NotNull] IEnumerable<PostObject> posts)
        {
            transform.DeleteAllChildren();
            
            var sortedPosts = posts.OrderByDescending(x => new DateTime(x.year, x.month, x.day, x.hour, x.minute, 0));
            foreach (var post in sortedPosts)
            {
                InstantiatePost(post);
            }
            
            StartCoroutine(FitContent());
        }
        
        [SuppressMessage("ReSharper", "Unity.InefficientPropertyAccess")]
        private IEnumerator FitContent() // Dirty hack because ContentSizeFitter needs a frame to adjust...
        {
            var fitter = GetComponentsInChildren<ContentSizeFitter>();
            foreach (var contentSizeFitter in fitter)
            {
                if (contentSizeFitter != null)
                {
                    yield return null;
                    contentSizeFitter.enabled = false;
                    contentSizeFitter.enabled = true;
                }
            }
        }
        
        private void InstantiatePost([NotNull] PostObject post)
        {
            var instance = Instantiate(postPrefab, transform);
            var script = instance.GetComponent<Post>();
            script.Initialize(post);
        }
    }
}