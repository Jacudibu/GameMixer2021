using JetBrains.Annotations;
using UnityEngine;

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

        [NotNull] public string GetTimestampString()
        {
            return DateHelper.GetTimestampString(year, month, day, hour, minute);
        }
    }
}
