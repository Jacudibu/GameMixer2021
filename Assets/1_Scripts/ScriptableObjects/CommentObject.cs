using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine.Serialization;

namespace ScriptableObjects
{
    [Serializable] 
    public class CommentObject
    {
        public CharacterObject character;
        public string text;

        [FormerlySerializedAs("minutes")] public short minute;
        public short hour;
        public short day;
        public short month;
        public short year;
        
        [FormerlySerializedAs("subComments")] public List<CommentResponse> responseComments;

        [NotNull] public string GetTimestampString()
        {
            return DateHelper.GetTimestampString(year, month, day, hour, minute);
        }
    }
}