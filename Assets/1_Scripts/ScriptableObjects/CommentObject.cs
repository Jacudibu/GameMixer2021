using JetBrains.Annotations;
using UnityEngine.Serialization;

namespace ScriptableObjects
{
    [System.Serializable] 
    public class CommentObject
    {
        public CharacterObject character;
        public string text;

        [FormerlySerializedAs("minutes")] public short minute;
        public short hour;
        public short day;
        public short month;
        public short year;

        [NotNull] public string GetTimestampString()
        {
            return DateHelper.GetTimestampString(year, month, day, hour, minute);
        }
    }
}