using System.Collections.Generic;
using JetBrains.Annotations;
using UI.Elements;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewDialogue", menuName = "FriendBook/Dialogue", order = 1)]
    public class DialogueObject : ScriptableObject
    {
        public List<DialogueElement> elements;

        [Header("Optional Stuff")]
        [Tooltip("Will trigger the specified dialogue after a set amount of time.")]
        [CanBeNull] public DialogueObject failSafeDialogue;
        public float failSafeDelayInSeconds;

        [Tooltip("This scene will be loaded once the dialogue is done.")]
        [CanBeNull] public SceneAsset sceneLoadedAtEnd;
    }
}
