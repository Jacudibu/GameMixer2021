using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Utility;

namespace UI
{
    public class PostCollection : SingletonBehaviour<PostCollection>
    {
        [FormerlySerializedAs("postWithPicture")] [SerializeField] private GameObject postPrefab;

        public void Initialize([NotNull] IEnumerable<PostObject> posts)
        {
            DeleteAllChildren();
            
            var sortedPosts = posts.OrderBy(x => new DateTime(x.year, x.month, x.day, x.hour, x.minute, 0));
            foreach (var post in sortedPosts)
            {
                InstantiatePost(post);
            }

            StartCoroutine(FitContent());
        }

        [SuppressMessage("ReSharper", "Unity.InefficientPropertyAccess")]
        private IEnumerator FitContent() // Dirty hack because ContentSizeFitter needs a frame to adjust...
        {
            yield return null;
            var fitter = GetComponent<ContentSizeFitter>();
            fitter.enabled = false;
            fitter.enabled = true;
        }

        private void DeleteAllChildren()
        {
            for (var i = transform.childCount - 1; i >= 0; i--)
            {
                var child = transform.GetChild(i);
                Destroy(child.gameObject);
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