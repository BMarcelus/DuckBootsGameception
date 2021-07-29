using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerIndicator : MonoBehaviour
{
    private Image bckgroundSpriteRenderer;

    private HorizontalLayoutGroup iconGroup;
    private Image[] icons;

    public Sprite redSprite;
    public Sprite blueSprite;
    public Sprite yellowSprite;
    public Sprite whiteSprite;
    public Sprite happySprite;
    public Sprite angrySprite;

    private void Awake()
    {
        bckgroundSpriteRenderer = GetComponent<Image>();
        iconGroup = GetComponentInChildren<HorizontalLayoutGroup>();
        icons = iconGroup.GetComponentsInChildren<Image>();
    }

    public void SetColor(ColorType colorType)
    {
        List<Sprite> iconSprites = new List<Sprite>();

        switch (colorType)
        {
            case ColorType.White:
                iconSprites.Add(whiteSprite);
                break;
            case ColorType.Red:
                iconSprites.Add(redSprite);
                break;
            case ColorType.Blue:
                iconSprites.Add(blueSprite);
                break;
            case ColorType.Green:
                iconSprites.Add(blueSprite);
                iconSprites.Add(yellowSprite);
                break;
            case ColorType.Yellow:
                iconSprites.Add(yellowSprite);
                break;
            case ColorType.Orange:
                iconSprites.Add(redSprite);
                iconSprites.Add(yellowSprite);
                break;
            case ColorType.Purple:
                iconSprites.Add(redSprite);
                iconSprites.Add(blueSprite);
                break;
            case ColorType.Black:
                iconSprites.Add(redSprite);
                iconSprites.Add(blueSprite);
                iconSprites.Add(yellowSprite);
                break;
        }

        SetIconsEnabled(iconSprites);
    }

    public void SetSatisfaction(bool isSatisfied)
    {
        List<Sprite> iconSprites = new List<Sprite>();
        if (isSatisfied)
        {
            iconSprites.Add(happySprite);
        }
        else
        {
            iconSprites.Add(angrySprite);
        }
        SetIconsEnabled(iconSprites);
    }

    private void SetIconsEnabled(List<Sprite> _iconSprites)
    {
        foreach (Image s in icons)
        {
            s.gameObject.SetActive(false);
        }

        for (int i = 0; i < _iconSprites.Count; i++)
        {
            icons[i].gameObject.SetActive(true);
            icons[i].sprite = _iconSprites[i];
        }
    }

}
