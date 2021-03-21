using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewPost", menuName = "FriendBook/Post", order = 1)]
    public class PostObject : ScriptableObject
    {
        [CanBeNull] public Sprite image;
        public CharacterObject character;
        public string text;

        public short minute;
        public short hour;
        public short day;
        public short month;
        public short year;
        
        public CommentObject[] comments; 
        
        [System.Serializable] 
        public class CommentObject
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
