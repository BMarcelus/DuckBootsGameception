using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingController : MonoBehaviour {
    public Item.ItemType[] recipe;
    public int progress;
    public List<GameObject> strikethroughs;

    public Sprite[] recipeSprites;
    public GameObject[] exitWarpPoints;

    public TextMesh timerText;
    float t;
    bool Finished;

    void Start() {
        // Choose a random recipe
        //Random.InitState((int)DateTime.Now.Ticks);
        int recipeIndex = Random.Range(0, recipeSprites.Length);
        if (recipeIndex == 0) {
            recipe = new Item.ItemType[] {
                Item.ItemType.Egg,
                Item.ItemType.Cheese,
                Item.ItemType.Bacon,
                Item.ItemType.Bread,
            };
        }
        else if (recipeIndex == 1) {
            recipe = new Item.ItemType[] {
                Item.ItemType.Bacon,
                Item.ItemType.Lettuce,
                Item.ItemType.Tomato,
                Item.ItemType.Bread,
            };
        }
        else if (recipeIndex == 2) {
            recipe = new Item.ItemType[] {
                Item.ItemType.Egg,
                Item.ItemType.Tomato,
                Item.ItemType.Cheese,
                Item.ItemType.Mushroom,
                Item.ItemType.Bread,
            };
        }
        else if (recipeIndex == 3) {
            recipe = new Item.ItemType[] {
                Item.ItemType.Mushroom,
                Item.ItemType.Lettuce,
                Item.ItemType.Cheese,
                Item.ItemType.Bacon,
                Item.ItemType.Bread,
            };
        }
        transform.Find("RecipeSprite").GetComponent<SpriteRenderer>().sprite = recipeSprites[recipeIndex];

        // Disable all strikethroughs
        strikethroughs = new List<GameObject>();
        foreach (Transform child in transform) {
            if (child.gameObject.name.StartsWith("Strikethrough")) {
                strikethroughs.Add(child.gameObject);
                child.gameObject.SetActive(false);
            }
        }

        // Disable all the exit warp points until you have completed the minigame
        for (int i=0; i<exitWarpPoints.Length; i++) {
            exitWarpPoints[i].SetActive(false);
        }
    }

    void Update() {
        if (!Finished) {
            t += Time.deltaTime;
            string subSeconds = (t - Mathf.Floor(t)).ToString(".00");
            string minutes = Mathf.Floor(t/60).ToString("00");
            string seconds = (Mathf.Floor(t) - Mathf.Floor(t/60)*60).ToString("00");
            timerText.text = minutes + ":" + seconds + subSeconds;
        }
    }

    public bool AdvanceRecipe() {
        if (Finished)  return false;

        var held = MetaGameManager.instance.GetHeldItem();
        if (held != recipe[progress])  return false;

        strikethroughs[progress].SetActive(true);
        progress++;
        if (progress == recipe.Length) {
            for (int i=0; i<exitWarpPoints.Length; i++) {
                exitWarpPoints[i].SetActive(true);
            }
            Finished = true;
        }

        return true;
    }
}
