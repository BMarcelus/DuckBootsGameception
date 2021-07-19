using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class SceneTransitionController : MonoBehaviour
{
    private static SceneTransitionController instance;
    public static SceneTransitionController Instance {
        get {
            if (instance == null)
            {
                instance = FindObjectOfType<SceneTransitionController>();
            }
            return instance;
        }
    }

    public event Action StartGameTransition = delegate { };
    public event Action EndGameTransition = delegate { };
    public event Action OnGameUnload = delegate { };
    public event Action OnGameLoad = delegate { };

    protected CanvasGroup faderCanvasGroup;
    protected float fadeDuration = 1f;

    private bool isFading;
    public bool IsFading { get { return isFading; } }

    private void Awake()
    {
        if (instance != null && instance != this) { Destroy(this); }
        else { instance = this; }

        faderCanvasGroup = GetComponent<CanvasGroup>();
    }

    public void FadeAndLoadGame()
    {
        if (isFading) { return; }

        StartCoroutine(FadeAndSwitchScenes());
    }

    // This is the main coroutine where it goes through the entire game transition
    private IEnumerator FadeAndSwitchScenes()
    {
        //!TODO: Tell game manager that player can't input here
        Time.timeScale = 0;

        yield return StartCoroutine(Fade(1f));
        faderCanvasGroup.alpha = 1f;
        OnGameUnload?.Invoke();

        //yield return null;

        OnGameLoad?.Invoke();

        Time.timeScale = 1;

        yield return StartCoroutine(Fade(0f));


        //!TODO: Tell game manager that player can input here
    }

    //Coroutine to fade the loading screen in and out
    public IEnumerator Fade(float finalAlpha)
    {
        isFading = true;

        if (finalAlpha == 1f)
        {
            StartGameTransition?.Invoke();
        }

        faderCanvasGroup.blocksRaycasts = true;

        float fadeSpeed = Mathf.Abs(faderCanvasGroup.alpha - finalAlpha) / fadeDuration;

        while (!Mathf.Approximately(faderCanvasGroup.alpha, finalAlpha))
        {
            faderCanvasGroup.alpha = Mathf.MoveTowards(faderCanvasGroup.alpha, finalAlpha, fadeSpeed * Time.unscaledDeltaTime);
            yield return null;
        }

        isFading = false;

        if (finalAlpha == 0f)
        {
            EndGameTransition?.Invoke();
        }

        faderCanvasGroup.blocksRaycasts = false;
    }
}