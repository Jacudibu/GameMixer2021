using UI;
using UnityEditor;
using UnityEngine;

public class InBetweenScreen : MonoBehaviour
{
    public SceneAsset nextScene;
    
    public void OnContinueButtonClick()
    {
        ScreenFade.Instance.FadeToBlackThenLoadScene(nextScene);
    }
}
