using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        this.gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5.0f)
        {
            gameManager.GetComponent<GameManager>().IncreasePonit();
            Destroy(gameObject);            
        }       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.tag = "Untagged";
    }
}
