using System;
using Enums;
using ScriptableObjects;

namespace UI.Elements
{
    [Serializable]
    public class DialogueElement
    {
        public CharacterObject character;
        public string text;
        public HorizontalPosition alignment; 
    }
}