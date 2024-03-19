using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomController : MonoBehaviour
{
    public float fallSpeed = 3f; 
    public float destroyHeight = -5f;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        if (transform.position.y < destroyHeight)
        {
            DestroyBoom();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Explode");
            DestroyBoom();
        }
    }

    public void DestroyBoom()
    {
        gameObject.SetActive(false);
    }
}
