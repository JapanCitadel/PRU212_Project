
﻿using System.Collections;

using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    float xSpeed;

    float endPosition;
    float Screenwidth;
    int direction = 1;

    [SerializeField]
    float ySpeed;
    float startPosition;
    float endPosition;
    float Screenwidth;
    float ScreenHeight;
    int xDirection = 1;
    int yDirection = 1;
>>>>>>> 2c1c6c604d9d01330df1ed2058bbdbcd3ec9e90f

    void Start()
    {
        float halfScreenWidth = Camera.main.orthographicSize * Camera.main.aspect;
<<<<<<< HEAD
        startPosition = -halfScreenWidth;
        endPosition = halfScreenWidth;
        Screenwidth = halfScreenWidth;
=======
        startPosition = -halfScreenWidth -2;
        endPosition = halfScreenWidth +2;
        Screenwidth = halfScreenWidth;
        ScreenHeight = Camera.main.orthographicSize;

        // Set initial direction
        FlipCharacter();
>>>>>>> 2c1c6c604d9d01330df1ed2058bbdbcd3ec9e90f
    }

    void Update()
    {
        MoveCharacter();
        CheckScreenBounds();
    }

    void MoveCharacter()
    {
<<<<<<< HEAD
        float newPositionX = transform.position.x - direction * xSpeed * Time.deltaTime; // Đảo ngược hướng di chuyển

        transform.position = new Vector2(newPositionX, transform.position.y);
    }


=======
        float newPositionX = transform.position.x + xDirection * xSpeed * Time.deltaTime;
        transform.position = new Vector2(newPositionX, transform.position.y);
    }

>>>>>>> 2c1c6c604d9d01330df1ed2058bbdbcd3ec9e90f
    void CheckScreenBounds()
    {
        if (transform.position.x > endPosition || transform.position.x < startPosition)
        {
<<<<<<< HEAD
            direction *= -1;
            FlipCharacter();
        }
        
=======
            Destroy(gameObject);
        }

        if (transform.position.y > ScreenHeight || transform.position.y < -ScreenHeight)
        {
            Destroy(gameObject);
        }
>>>>>>> 2c1c6c604d9d01330df1ed2058bbdbcd3ec9e90f
    }

    public void SetXDirection(int x)
    {
<<<<<<< HEAD
        direction = x;
        FlipCharacter();
    }

    void FlipCharacter()
    {
        transform.localScale = new Vector3(direction, 1, 1);
    }


=======
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

>>>>>>> 2c1c6c604d9d01330df1ed2058bbdbcd3ec9e90f
    public void SetXSpeed(float x)
    {
        xSpeed = x;
    }

<<<<<<< HEAD
}
=======
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
>>>>>>> 2c1c6c604d9d01330df1ed2058bbdbcd3ec9e90f
