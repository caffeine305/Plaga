
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movedor : MonoBehaviour {

    private float moveSpeed;

    public GameObject shot;
    public Transform spawnPoint;
    public float fireRate = 0.5f;
    private float nextShot = 0.25f;
    private float dir_x;
    private float dir_y;
    private float dir_ang;
    Vector3 offst;
     

    void Start() {
        Vector2 bulletPos = GetComponent<Rigidbody2D>().velocity;
        Vector3 offst = new Vector3(1f,0f,0f);
        moveSpeed = 6.0f;

    }

    void FixedUpdate() {

        Shoot();


        float velx = Input.GetAxis("Horizontal") * moveSpeed;
        float vely = Input.GetAxis("Vertical") * moveSpeed;

        transform.Translate(Vector2.right * velx * Time.deltaTime);
        transform.Translate(Vector2.up * vely * Time.deltaTime);

        dir_x = velx;
        dir_y = vely;
        dir_ang = Mathf.Tan(dir_y / dir_x);

    }

    void Shoot()
    {
        if ((Input.GetButton("Fire1")) && (Time.time > nextShot))
        {
            //Quaternion direccion = Quaternion.Euler(dir_ang, 0, 0);//checar el eje
            GameObject objbala = Instantiate(shot, transform.position + offst, Quaternion.identity) as GameObject;

            //Vector3 forwardVel = transform.forward * 100.0f * dir_x;
            //Vector3 horizontalVel = transform.right * 100.0f * dir_y;

            //Debug.Log(forwardVel);
            //Debug.Log(horizontalVel);

            shot.GetComponent<Rigidbody2D>().velocity = transform.right * 10;
            //shot.GetComponent<Rigidbody>().AddForce(transform.right * 10);

            nextShot = Time.time + fireRate;
            //Instantiate(shot, spawnPoint.position, spawnPoint.rotation);
        }
    //Rigidbody2D bulletInstance = Instantiate(shot, transform.position, Quaternion.Euler(new Vector3(0, 0, 1))) as Rigidbody2D;
    //bulletInstance.velocity = transform.forward * moveSpeed;
     
    }
}
