using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;
using Utility;

namespace UI
{
    public class PostCollection : SingletonBehaviour<PostCollection>
    {
        [FormerlySerializedAs("postWithPicture")] [SerializeField] private GameObject postPrefab;

        public void Initialize([NotNull] IEnumerable<PostObject> posts)
        {
            DeleteAllChildren();
            
            var rectTransform = (RectTransform) gameObject.transform;
            var height = 0f;

            var sortedPosts = posts.OrderBy(x => new DateTime(x.year, x.month, x.day, x.hour, x.minute, 0));
            foreach (var post in sortedPosts)
            {
                var instance = InstantiatePost(post);
                height += ((RectTransform) instance.transform).sizeDelta.y;
            }
            
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, height);
        }

        private void DeleteAllChildren()
        {
            for (var i = transform.childCount - 1; i >= 0; i--)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        [NotNull] private GameObject InstantiatePost([NotNull] PostObject post)
        {
            var instance = Instantiate(postPrefab, transform);
            var script = instance.GetComponent<Post>();
            script.Initialize(post);
            return instance;
        }
    }
}