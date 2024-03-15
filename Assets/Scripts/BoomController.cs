using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomController : MonoBehaviour
{
<<<<<<< HEAD
    public float fallSpeed = 5f; 
=======
    public float fallSpeed = 3f; 
>>>>>>> f129210a49c12b3facf67f6909d2e3041fd6c74d
    public float destroyHeight = -5f; 

    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        if (transform.position.y < destroyHeight)
        {
            Destroy(gameObject);
        }
    }
}
