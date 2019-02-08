using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectil : MonoBehaviour {
    public float speed = 30.0f;

    private Rigidbody2D rb;

    public float moveHorizontal;
    public float moveVertical;
    public bool mover = false;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        DestroyObjectDelayed();
    }

    void FixedUpdate()
    {
        if(mover)
        {
            Vector2 movement = new Vector3(moveHorizontal, moveVertical);
            rb.AddForce(movement * speed);
        }
    }

    void DestroyObjectDelayed()
    {
        Destroy(gameObject, 2);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log(col.gameObject.name);
        //Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Bug")
        {
            Destroy(col.gameObject, 1.0f);
            Destroy(gameObject, 1.0f);
        }
    }
}
