using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingController : MonoBehaviour {
    public enum Ingredient {
        Bread,
        Cheese,
        Tomato,
        Lettuce,
        Mushroom,
        Egg,
        Bacon,
    }

    Ingredient[] recipe;
    int progress;
    List<GameObject> strikethroughs;

    public Sprite[] recipeSprites;
    public GameObject[] exitWarpPoints;

    void Start() {
        // Choose a random recipe
        int recipeIndex = 0;
        recipe = new Ingredient[3] {
            Ingredient.Bread,
            Ingredient.Egg,
            Ingredient.Cheese,
        };
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

    public void AdvanceRecipe() {
        if (progress == recipe.Length)  return;

        strikethroughs[progress].SetActive(true);
        progress++;
        if (progress == recipe.Length) {
            for (int i=0; i<exitWarpPoints.Length; i++) {
                exitWarpPoints[i].SetActive(true);
            }
        }
    }
}
