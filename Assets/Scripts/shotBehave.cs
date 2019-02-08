using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotBehave : MonoBehaviour {

    public float speed;
    Rigidbody rBody;
    //public GameObject objPlayer;
    public float angulo = 0.0f;

    Vector2 hForce;
    Vector2 vForce;

    void Start() {
        //GetComponent<Rigidbody2D>().velocity = transform.position * speed;
        
        rBody = GetComponent<Rigidbody>();
        //rBody.velocity = transform.rotation * speed;
        //Vector3 forwardVel = transform.forward * speed * moveVertical;
        //Vector3 horizontalVel = transform.right * speed * moveHorizontal;

        //rBody.velocity = forwardVel + horizontalVel;
        //rBody.velocity = objPlayer.transform.right * speed;
        //rBody.velocity = Input.GetAxis("Horizontal");

        //rBody.AddForce(objPlayer.transform.right * speed);
    }

    private void Update()
    {
       this.transform.position += transform.right * speed / 2;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
    void OnTriggerEnter(Collider otherCol)
    {
        if (otherCol.tag == "Bug")
        {
            return;
        }

        Destroy(otherCol.gameObject);
        Destroy(this.gameObject);
    }

}
