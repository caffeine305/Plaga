using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour {
    public float speed = 8.0f;

    private Rigidbody2D rb;

    public GameObject healthBar;
    float healthBarPercnt;

    public proyectil projectile;
    public float fireDelta = 0.5F;

    private float nextFire = 0.5F;
    //private proyectil newProjectile;
    private float myTime = 0.0F;
    public float dirX;
    public float dirY;
    public float angulo = 0.0f;
    public float direccion = 0.0f;
    Vector3 offst = new Vector3(1, 0,0);

    int maxHP = 100;
    public int actualHP;
    public float fixedtime;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        actualHP = maxHP;
        healthBarPercnt = (float)this.actualHP / (float)maxHP;
    }

    void SetHealthBarSize(float Percentage)
    {
        healthBar.transform.localScale = new Vector3(Percentage, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    void OnCollisionEnter(Collider other)
    {
            if (other.gameObject.tag == "Bug")
            {
                actualHP = actualHP - 2;

                healthBarPercnt = (float)this.actualHP / (float)maxHP;
                SetHealthBarSize(healthBarPercnt);
                Debug.Log("HP: " + actualHP);
                Debug.Log("%: " + healthBarPercnt);

            }

        if (actualHP <= 0)
            Destroy(this.gameObject);
    }

    void FixedUpdate()
    {
        dirX = Input.GetAxis("Horizontal");
        dirY = Input.GetAxis("Vertical");
        
        angulo = Mathf.Atan2(dirY, dirX);
        if((dirX + dirY) != 0.0f)
        {
            if (angulo != float.NaN) direccion = angulo;
        }

        Vector2 movement = new Vector2(dirX, dirY);

        rb.AddForce(movement * speed);
    }

    void Update()
    {

        myTime = myTime + Time.deltaTime;

        if (Input.GetButton("Fire1") && myTime > nextFire)
        {
            nextFire = myTime + fireDelta;
            proyectil newProjectile = Instantiate(projectile, transform.position
                , transform.rotation);
            newProjectile.moveHorizontal = Mathf.Cos(direccion);
            newProjectile.moveVertical = Mathf.Sin(direccion);
            newProjectile.mover = true;

            nextFire = nextFire - myTime;
            myTime = 0.0F;
        }
    }
}
