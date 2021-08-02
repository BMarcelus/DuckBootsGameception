using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemIndicator : MonoBehaviour
{
    private Image bckgroundSpriteRenderer;
    private Image icon;

    public Sprite SatisfiedCustomer;

    private void Awake()
    {
        bckgroundSpriteRenderer = GetComponent<Image>();
        icon = transform.GetChild(0).GetComponent<Image>();
    }

    public void Show(Sprite sprite)
    {
        icon.sprite = sprite;
    }

    public void Hide()
    {
        StartCoroutine(ShowSatisfactionTheHide());
    }

    private IEnumerator ShowSatisfactionTheHide()
    {
        icon.sprite = SatisfiedCustomer;
        yield return new WaitForSeconds(1f);

        this.gameObject.SetActive(false);
    }
}
