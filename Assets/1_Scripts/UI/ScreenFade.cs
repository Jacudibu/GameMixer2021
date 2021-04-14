using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utility;

namespace UI
{
    public class ScreenFade : SingletonBehaviour<ScreenFade>
    {
        [SerializeField] private Image image;
        [SerializeField] private float fadeSpeed = 1;

        private void Awake()
        {
            FadeFromBlack();
        }

        public void FadeToBlackThenLoadScene([NotNull] Object sceneAsset)
        {
            StartCoroutine(Fade(0, 1));
            StartCoroutine(LoadSceneAfterDelay(fadeSpeed * 1.25f, sceneAsset));
        }

        public void FadeFromBlack()
        {
            StartCoroutine(Fade(1, 0));
        }

        private IEnumerator LoadSceneAfterDelay(float delay, [NotNull] Object sceneAsset)
        {
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(sceneAsset.name);
        }

        private IEnumerator Fade(float fromAlpha, float toAlpha)
        {
            image.enabled = true;
            image.color = new Color(0, 0, 0, fromAlpha);

            for (var t = 0f; t < 1; t += Time.deltaTime * fadeSpeed)
            {
                image.color = Color.Lerp( new Color(0, 0, 0, fromAlpha),  new Color(0, 0, 0, toAlpha), t);
                yield return new WaitForEndOfFrame();
            }
            
            image.color = new Color(0, 0, 0, toAlpha);
            if (toAlpha < 0.1)
            {
                image.enabled = false;
            }
        }
    }
}
