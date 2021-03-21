using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewPost", menuName = "FriendBook/Post", order = 1)]
    public class PostObject : ScriptableObject
    {
        [FormerlySerializedAs("picture")] [CanBeNull] public Sprite image;
        public CharacterObject character;
        public string text;

        [FormerlySerializedAs("minutes")] public short minute;
        public short hour;
        public short day;
        public short month;
        [FormerlySerializedAs("yeah")] public short year;
        
        public Comment[] comments; 
        
        [System.Serializable] 
        public class Comment
        {
            public CharacterObject character;
            public string text;

            public short minutes;
            public short hour;
            public short day;
            public short month;
            public short yeah;
        }
    }
}
