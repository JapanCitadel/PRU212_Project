using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    float xSpeed;
    [SerializeField]
    float ySpeed;
    float startPosition;
    float endPosition;
    float Screenwidth;
    float ScreenHeight;
    int xDirection = 1;
    int yDirection = 1;

    void Start()
    {
        float halfScreenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        startPosition = -halfScreenWidth -2;
        endPosition = halfScreenWidth +2;
        Screenwidth = halfScreenWidth;
        ScreenHeight = Camera.main.orthographicSize;

        // Set initial direction
        FlipCharacter();
    }

    void Update()
    {
        MoveCharacter();
        CheckScreenBounds();
    }

    void MoveCharacter()
    {
        float newPositionX = transform.position.x + xDirection * xSpeed * Time.deltaTime;
        transform.position = new Vector2(newPositionX, transform.position.y);
    }

    void CheckScreenBounds()
    {
        if (transform.position.x > endPosition || transform.position.x < startPosition)
        {
            Destroy(gameObject);
        }

        if (transform.position.y > ScreenHeight || transform.position.y < -ScreenHeight)
        {
            Destroy(gameObject);
        }
    }

    public void SetXDirection(int x)
    {
        xDirection = x;
        FlipCharacter();
    }

    public void SetYDirection(int y)
    {
        yDirection = y;
    }

    void FlipCharacter()
    {
        transform.localScale = new Vector3(xDirection, 1, 1);
    }

    public void SetXSpeed(float x)
    {
        xSpeed = x;
    }

    public void SetYSpeed(float y)
    {
        ySpeed = y;
    }

    public void SetSpeed(float x, float y)
    {
        xSpeed = x;
        ySpeed = y;
    }
}