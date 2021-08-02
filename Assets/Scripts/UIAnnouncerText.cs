using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using RedBlueGames.Tools.TextTyper;

[RequireComponent(typeof(TMP_Text)), RequireComponent(typeof(TextTyper))]
public class UIAnnouncerText : MonoBehaviour
{
    private TMP_Text text;
    private TextTyper textTyper;
    bool isFading;
    public float fadeDuration = 1f;

    private MetaGameManager mgm;
    private SceneTransitionController stc;

    private void Awake()
    {
        textTyper = GetComponent<TextTyper>();
        text = GetComponent<TMP_Text>();
        stc = SceneTransitionController.Instance;
    }

    private void OnEnable()
    {
        stc.OnGameLoad += ShowCurrGameInstructions;
    }

    private void OnDisable()
    {
        stc.OnGameLoad -= ShowCurrGameInstructions;
    }

    private void Start()
    {
        mgm = MetaGameManager.instance;
        this.textTyper.CharacterPrinted.AddListener(this.HandleCharacterPrinted);
        SetTextAlpha(0f);
    }

    public void ShowCurrGameInstructions()
    {
        if (mgm.currentGame == null) { return; }

        ShowAndFadeText(mgm.currentGame.announcerText, 5f);
    }

    public void ShowAndFadeText(string _text, float timeOutAmount)
    {
        ShowText(_text);
        StartCoroutine(timeOutText(timeOutAmount));
    }

    public void ShowText(string _text)
    {
        StopAllCoroutines();
        isFading = false;

        text.text = "";
        textTyper.TypeText(_text, .1f);
        SetTextAlpha(1f);
    }

    public void HideText()
    {
        if (isFading)
        {
            StopAllCoroutines();
            isFading = false;
        }

        StartCoroutine(textFade(0f));
    }

    private void HideTextImmediate()
    {
        StopAllCoroutines();
        isFading = false;
        SetTextAlpha(0f);
    }

    IEnumerator textFade(float finalAlpha)
    {
        isFading = true;

        if (finalAlpha != 0)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0f);
        }
        else
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, 1f);
        }
        float currentAlpha = text.color.a;
        float fadeSpeed = Mathf.Abs(text.color.a - finalAlpha) / fadeDuration;

        while (!Mathf.Approximately(text.color.a, finalAlpha))
        {
            currentAlpha = Mathf.MoveTowards(currentAlpha, finalAlpha, fadeSpeed * Time.deltaTime);
            text.color = new Color(text.color.r, text.color.g, text.color.b, currentAlpha);
            yield return null;
        }

        isFading = false;
    }

    private IEnumerator timeOutText(float time)
    {
        yield return new WaitForSeconds(time);
        HideText();
    }

    private void SetTextAlpha(float textAlpha)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, textAlpha);
    }

    private void HandleCharacterPrinted(string printedCharacter)
    {
        // Do not play a sound for whitespace
        if (printedCharacter == " " || printedCharacter == "\n")
        {
            return;
        }

        //Play text sound here!
    }
}
