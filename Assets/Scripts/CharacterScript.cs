using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterScript : MonoBehaviour
{
    Animator animator;
    SpriteRenderer sprite;
    Rigidbody2D rigit;
    public Transform EatPoint;
    public float EatRange = 0.5f;
    public LayerMask EnemyLayer, ItemLayer;
    float PrevPosition;
    float NowDistance, PrevDistance;
    float size = 1f;
    int eatenFish = 0;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rigit = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!UIControllerScript.isPause)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

            worldPosition.z = 0f;
            PrevPosition = transform.position.x;
            NowDistance = Mathf.Abs(worldPosition.x - 0);
            PrevDistance = Mathf.Abs(PrevPosition - 0);

            if ((NowDistance < PrevDistance && worldPosition.x < 0) || (NowDistance > PrevDistance && worldPosition.x > 0))
            {
                sprite.flipX = true;
                EatPoint.transform.position = new Vector3(transform.position.x + 0.615f, transform.position.y, 0f);
            }
            else if ((NowDistance > PrevDistance && worldPosition.x < 0) || (NowDistance < PrevDistance && worldPosition.x > 0))
            {
                sprite.flipX = false;
                EatPoint.transform.position = new Vector3(transform.position.x - 0.615f, transform.position.y, 0f);
            }

            transform.position = worldPosition;
            Swimming();
            Eat();
        }
    }

    private void Swimming()
    {
        if (NowDistance != PrevDistance)
        {
            animator.SetBool("IsSwim", true);
        }
        else
        {
            animator.SetBool("IsSwim", false);
        }
    }
    private void Eat()
    {
        Collider2D[] eatEnemies = Physics2D.OverlapCircleAll(EatPoint.position, EatRange, EnemyLayer);
        Collider2D[] eatItems = Physics2D.OverlapCircleAll(EatPoint.position, EatRange, ItemLayer);
        foreach (Collider2D enemy in eatEnemies)
        {
            animator.SetTrigger("IsEat");
            enemy.gameObject.SetActive(false);
            GrowUp(eatenFish);
        }
        foreach (Collider2D item in eatItems)
        {
            animator.SetTrigger("IsEat");
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (EatPoint == null)
        {
            return;
        }
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(EatPoint.position, EatRange);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            this.gameObject.SetActive(false);
            Scene currentScene = SceneManager.GetActiveScene();
            UIControllerScript uiController = GameObject.FindObjectOfType<UIControllerScript>();
            if (uiController != null)
            {
                //PlayerPrefs.SetInt("EnemyCount", uiController.EnemyCount);
            }
            SceneManager.LoadScene("EndgameScene");
        }

        if (collision.gameObject.CompareTag("Enemy2") && size < 2f)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            Eat();
        }

        if(collision.gameObject.CompareTag("Enemy3") && size < 3f)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            Eat();
        }

        if (collision.gameObject.CompareTag("Enemy4") && size < 4f)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            Eat();
        }
    }

    public void GrowUp(int eatenFish)
    {
        eatenFish++;
        if (eatenFish >= 10)
        {
            size++;
            transform.localScale = new Vector3(size, size, 1f);
            eatenFish = 0;
        }
    } 
}
