using System.Collections.Generic;
using JetBrains.Annotations;
using UI.Elements;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewDialogue", menuName = "FriendBook/Dialogue", order = 1)]
    public class DialogueObject : ScriptableObject
    {
        public List<DialogueElement> elements;

        [CanBeNull] public DialogueObject failSafeDialogue;
        public float failSafeDelayInSeconds;
    }
}
