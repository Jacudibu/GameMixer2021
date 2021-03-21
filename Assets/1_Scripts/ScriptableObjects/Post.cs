using JetBrains.Annotations;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewPost", menuName = "FriendBook/Post", order = 1)]
    public class Post : ScriptableObject
    {
        [CanBeNull] public Sprite picture;
        public Character character;
        public string text;

        public short minutes;
        public short hour;
        public short day;
        public short month;
        public short yeah;
        
        public Comment[] comments;
        
        [System.Serializable] 
        public class Comment
        {
            public Character character;
            public string text;

            public short minutes;
            public short hour;
            public short day;
            public short month;
            public short yeah;
        }
    }
}
