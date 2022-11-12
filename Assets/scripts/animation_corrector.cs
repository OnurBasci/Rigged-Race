using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation_corrector : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        animator.SetFloat("axe", Mathf.Abs(rb.velocity.x));
    }
}
