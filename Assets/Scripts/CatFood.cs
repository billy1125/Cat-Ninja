using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFood : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.tag = "Untagged";
    }
}
