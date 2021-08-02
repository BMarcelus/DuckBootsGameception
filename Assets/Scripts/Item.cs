using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType {
        None,
        FakeItem,
        Boots,
        Bread,
        Cheese,
        Tomato,
        Lettuce,
        Mushroom,
        Egg,
        Bacon,
        Lilypad,
        IceKey,
        Key,
        DuckBoots
    }

    public ItemType itemType;
    public Transform visualHolder;

    protected SpriteRenderer sr;
    public SpriteRenderer SR => sr;

    protected ColorType colorType = ColorType.White;

    public void SetItem(Item.ItemType itemType) {
        this.itemType = itemType;
        GameObject visualPrefab = MetaGameManager.instance.GetItemVisualPrefab(itemType);
        foreach (Transform child in visualHolder) {
            GameObject.Destroy(child.gameObject);
        }
        if(visualPrefab==null)return;       
        GameObject visual = Instantiate(visualPrefab, visualHolder.position, visualHolder.rotation);
        visual.transform.parent = visualHolder;

        sr = visual.GetComponent<SpriteRenderer>();
        if (!sr)
            sr = visual.GetComponentInChildren<SpriteRenderer>();

        SetColor(ColorType.White);
    }

    public void SetItem(Item.ItemType itemType, GameObject visualPrefab) {
        this.itemType = itemType;
        foreach (Transform child in visualHolder) {
            GameObject.Destroy(child.gameObject);
        }
        if(visualPrefab==null)return;       
        GameObject visual = Instantiate(visualPrefab, visualHolder.position, visualHolder.rotation);
        visual.transform.parent = visualHolder;

        sr = visual.GetComponent<SpriteRenderer>();
        if(!sr)
            sr = visual.GetComponentInChildren<SpriteRenderer>();

        SetColor(ColorType.White);
    }

    public void SetItem(Item item)
    {
        this.itemType = item.itemType;
        GameObject visualPrefab = MetaGameManager.instance.GetItemVisualPrefab(itemType);
        foreach (Transform child in visualHolder)
        {
            GameObject.Destroy(child.gameObject);
        }
        if (visualPrefab == null) return;
        GameObject visual = Instantiate(visualPrefab, visualHolder.position, visualHolder.rotation);
        visual.transform.parent = visualHolder;

        sr = visual.GetComponent<SpriteRenderer>();
        if (!sr)
            sr = visual.GetComponentInChildren<SpriteRenderer>();

        SetColor(item.GetColor());
    }

    virtual public void Triggered(GameObject gameObject) {

    }

    protected virtual void Awake()
    {

    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {

    }

    public void SetColor(ColorType _colorType)
    {
        colorType = _colorType;
        switch (colorType)
        {
            case ColorType.White:
                sr.color = Color.white;
                break;
            case ColorType.Red:
                sr.color = Color.red;
                break;
            case ColorType.Blue:
                sr.color = Color.blue;
                break;
            case ColorType.Green:
                sr.color = Color.green;
                break;
            case ColorType.Yellow:
                sr.color = Color.yellow;
                break;
            case ColorType.Orange:
                sr.color = new Color(1, .65f, 0);
                break;
            case ColorType.Purple:
                sr.color = Color.magenta;
                break;
            case ColorType.Black:
                sr.color = Color.black;
                break;
        }
    }

    public ColorType GetColor()
    {
        return colorType;
    }

}

public enum ColorType
{
    White,
    Red,
    Blue,
    Green,
    Yellow,
    Orange,
    Purple,
    Black
}
