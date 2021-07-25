using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAnimatable : MonoBehaviour
{
    public Animator animator;

    protected float animationSpeed = 1f;

    protected virtual void Awake()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

        if (animator == null)
            animator = GetComponentInChildren<Animator>();
    }

    protected virtual void Start()
    {
        animator.speed = animationSpeed;
    }

    protected virtual void OnEnable()
    {

    }

    protected virtual void OnDisable()
    {

    }

    public virtual void SetAniDirection(Vector2 dir)
    {
        if (!animator.runtimeAnimatorController) { return; }

        if (dir != Vector2.zero)
        {
            animator.SetFloat("Vertical", dir.y);
            animator.SetFloat("Horizontal", dir.x);
        }
    }

    public void PlayAnimation(string sAnimation)
    {
        if (!animator.runtimeAnimatorController) { return; }

        animator.Play(sAnimation);
    }

    public void PlayAnimation(string sAnimation, int layer, float normalizedTime)
    {
        if (!animator.runtimeAnimatorController) { return; }

        animator.Play(sAnimation, layer, normalizedTime);
    }

    public void SetAnimationSpeed(float speed)
    {
        animationSpeed = speed;
        animator.speed = animationSpeed;
    }
}
