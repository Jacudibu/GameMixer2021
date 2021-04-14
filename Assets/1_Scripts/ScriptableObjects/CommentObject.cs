using System;
using System.Collections.Generic;
using UnityEngine.Serialization;

namespace ScriptableObjects
{
    [Serializable] 
    public class CommentObject
    {
        public CharacterObject character;
        public string text;

        [FormerlySerializedAs("subComments")] public List<CommentResponse> responseComments;
    }
}