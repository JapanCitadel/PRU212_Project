using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    float xSpeed;
    float startPosition;
    float endPosition;
    float Screenwidth;
    int direction = 1;

    void Start()
    {
        float halfScreenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        startPosition = -halfScreenWidth;
        endPosition = halfScreenWidth;
        Screenwidth = halfScreenWidth;
    }

    void Update()
    {
        MoveCharacter();
        CheckScreenBounds();
    }

    void MoveCharacter()
    {
        float newPositionX = transform.position.x - direction * xSpeed * Time.deltaTime; // Đảo ngược hướng di chuyển

        transform.position = new Vector2(newPositionX, transform.position.y);
    }


    void CheckScreenBounds()
    {
        if (transform.position.x > endPosition || transform.position.x < startPosition)
        {
            direction *= -1;
            FlipCharacter();
        }
        
    }

    public void SetXDirection(int x)
    {
        direction = x;
        FlipCharacter();
    }

    void FlipCharacter()
    {
        transform.localScale = new Vector3(direction, 1, 1);
    }


    public void SetXSpeed(float x)
    {
        xSpeed = x;
    }

}
