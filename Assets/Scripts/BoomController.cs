using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomController : MonoBehaviour
{
    public float fallSpeed; 
    float ScreenHeight;
    Animator animator;

    void Start()
    {
        ScreenHeight = Camera.main.orthographicSize * 2 + 10;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        if (transform.position.y < -ScreenHeight)
        {
            DestroyBoom();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DestroyBoom();
        }
    }

    public void DestroyBoom()
    {
        animator.SetTrigger("Explode");
        Debug.Log("phat no");
        gameObject.SetActive(false);
    }

    public void SetFallSpeed(float x)
    {
        fallSpeed = x;
    }
}
