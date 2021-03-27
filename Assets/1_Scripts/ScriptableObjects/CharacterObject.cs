using JetBrains.Annotations;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewCharacter", menuName = "FriendBook/Character", order = 1)]
    public class CharacterObject : ScriptableObject
    {
        public Sprite profilePicture;
        public string firstName;
        public string lastName;
    
        public string location;
    
        public short dayOfBirth;
        public short monthOfBirth;
        public short yearOfBirth;

        public string job;
        public string education;
        
        public string address;
        public string phone;
        public string email;
        
        public string[] hobbies;

        [NotNull] public string GetNameString()
        {
            return firstName + " " + lastName;
        }
    }
}
