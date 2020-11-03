using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1.5f;
    public Rigidbody2D rb;
    public GameObject DestoyEnemy;

   
    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(1.6f, 0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.rotation *= Quaternion.Euler(0f, 0f, 1f);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "DestoyEnemy")
        {
            Destroy(gameObject);
        }
    }

}
