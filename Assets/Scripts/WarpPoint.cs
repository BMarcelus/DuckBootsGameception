using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPoint : MonoBehaviour
{
    public GameManager game;
    public Vector2 facingDir = Vector2.zero;

    // Used https://onlinegiftools.com/convert-gif-to-sprite-sheet to convert from gif to sprite sheet
    public Sprite[] introFrames;
    public Sprite[] idleFrames;
    public Sprite[] hoverFrames;
    const float animSpeed = 5f;
    float t;
    enum State {
        Opening,
        Idle,
        Hover,
    }
    State state;
    SpriteRenderer sr;

    private void OnTriggerEnter2D(Collider2D other) {
        state = State.Hover;
        t = 0;
        MetaGameManager.instance.SwitchToGame(game);
    }
    void Start() {
        sr = GetComponent<SpriteRenderer>();
    }
    void Update() {
        // Check to see if we have set sprites, so we don't break people's scenes that don't have sprites set
        if (introFrames.Length == 0)  return;

        // Progress through animations
        if (state == State.Opening) {
            sr.sprite = introFrames[(int)Mathf.Floor(t)];
            t += Time.deltaTime*animSpeed;
            if (t >= introFrames.Length) {
                state = State.Idle;
                t = 1; // Set t to 1 instead of 0 since there is a duplicated frame in this transition
            }
        }
        else if (state == State.Idle) {
            t += Time.deltaTime*animSpeed;
            sr.sprite = idleFrames[(int)Mathf.Floor(t) % idleFrames.Length];
        }
        else if (state == State.Hover) {
            t += Time.deltaTime*animSpeed;
            sr.sprite = hoverFrames[(int)Mathf.Floor(t) % hoverFrames.Length];
        }
    }
}
