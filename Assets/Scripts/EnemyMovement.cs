using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    float xSpeed;
    [SerializeField]
    float ySpeed;
    float startPosition;
    float endPosition;
    float ScreenWidth;
    float ScreenHeight;
    float xDirection = 1;
    SpriteRenderer sprite;
    public float size;

    private AudioManager audioManager;

    private void Awake()
    {
        //audioManager=GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        ScreenWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect;
        startPosition = -ScreenWidth - 50;
        endPosition = ScreenWidth + 50; ;
        ScreenHeight = Camera.main.orthographicSize *2;
        sprite = GetComponent<SpriteRenderer>();
        size = transform.localScale.y;
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        MoveCharacter();
        CheckScreenBounds();
        audioManager = FindObjectOfType<AudioManager>();
    }

    void MoveCharacter()
    {
        float newPositionX = transform.position.x + xDirection * xSpeed * Time.deltaTime;
        transform.position = new Vector2(newPositionX, transform.position.y);
        if (xDirection == -1)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }
    }

    void CheckScreenBounds()
    {
        if (transform.position.x > endPosition || transform.position.x < startPosition)
        {
            this.gameObject.SetActive(false);
        }

        if (transform.position.y > ScreenHeight || transform.position.y < -ScreenHeight)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void SetXDirection(float x)
    {
        xDirection = x;
    }

    public void SetXSpeed(float x)
    {
        xSpeed = x;
    }

    void Eat()
    {
        UIControllerScript uiController = GameObject.FindObjectOfType<UIControllerScript>();
        if (size > GameObject.FindObjectOfType<CharacterScript>().size)
        {
            GameObject.FindObjectOfType<CharacterScript>().gameObject.SetActive(false);
            if (uiController != null)
            {
                PlayerPrefs.SetInt("EnemyCount", uiController.EnemyCount);
                PlayerPrefs.SetInt("Score", uiController.Score);
            }
            SceneManager.LoadScene(5);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Eat();
            audioManager.PlaySFX(audioManager.ancaClip);
            //Destroy(gameObject);
        }
    }
}