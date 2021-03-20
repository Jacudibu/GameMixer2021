using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Character", order = 1)]
public class Character : ScriptableObject
{
    public Sprite profilePicture;
    public string firstName;
    public string lastName;
    
    public short dayOfBirth;
    public short monthOfBirth;
    public short yearOfBirth;
}
