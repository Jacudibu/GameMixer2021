namespace ScriptableObjects
{
    [System.Serializable] 
    public class CommentObject
    {
        public CharacterObject character;
        public string text;

        public short minutes;
        public short hour;
        public short day;
        public short month;
        public short year;
    }
}