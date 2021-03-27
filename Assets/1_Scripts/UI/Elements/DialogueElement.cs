using System;
using Enums;

namespace UI.Elements
{
    [Serializable]
    public class DialogueElement
    {
        public string text;
        public HorizontalPosition alignment;
        public bool sentManually;
    }
}