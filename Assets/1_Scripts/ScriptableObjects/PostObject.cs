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

        [Range(0,59)] public short minute;
        [Range(0,23)] public short hour;
        [Range(1,30)] public short day;
        [Range(1,12)] public short month;
        public short year = 2021;
        
        public CommentObject[] comments;

        [NotNull] public string GetTimestampString()
        {
            return DateHelper.GetTimestampString(year, month, day, hour, minute);
        }
    }
}
