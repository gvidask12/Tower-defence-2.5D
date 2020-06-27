using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneFadeIn : MonoBehaviour
{
    public Image image;
    public AnimationCurve fadeAnimationCurve;

    private void Start()
    {
        StartCoroutine(fadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(fadeOut(scene));
    }

    IEnumerator fadeIn()
    {
        float t = 1f;
        while (t > 0f)
        {
            t -= Time.deltaTime;
            float a = fadeAnimationCurve.Evaluate(t);
            image.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
    }
    IEnumerator fadeOut(string scene)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = fadeAnimationCurve.Evaluate(t);
            image.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
        SceneManager.LoadScene(scene);
    }

}
