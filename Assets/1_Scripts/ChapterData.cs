using ScriptableObjects;
using UnityEngine;

public class ChapterData : MonoBehaviour
{
    [SerializeField] private Character character;

    public void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        UI.MainUI.Instance.Initialize(character);
    }
}