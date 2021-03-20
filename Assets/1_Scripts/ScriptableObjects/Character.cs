using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Character", order = 1)]
    public class Character : ScriptableObject
    {
        public Sprite profilePicture;
        public string firstName;
        public string lastName;
    
        public string location;
    
        public short dayOfBirth;
        public short monthOfBirth;
        public short yearOfBirth;

        public string[] hobbies;
    }
}
