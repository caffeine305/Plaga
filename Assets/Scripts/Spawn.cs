using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject enemy1;
    public GameObject enemy2;
    GameObject enemy;
    public float spawnTime;
	// Use this for initialization
	void Start () {
        StartCoroutine (RePositionWithDelay());
    }

    void SetRandomPosition()
    {
        float x = Random.Range(-13.0f, 13.0f);
        float y = Random.Range(-6.0f, 6.0f);
        Debug.Log("X,Z:" + x.ToString("F2") + " , " + y.ToString("F2"));

        transform.position = new Vector3(x, y, 0.0f); 
    }

    void SetRandomEnemy()
    {
        float val = Random.Range(0.1f, 2.0f);
        switch ((int)val)
        {
            case 1:
                enemy = enemy1;
                break;
            case 2:
                enemy = enemy2;
                break;
            default:
                enemy = enemy1;
                break;

        }

    }

    IEnumerator RePositionWithDelay()
    {
        float spawnTime = 1.5f;
        while (true) 
        {
            SetRandomPosition();
            SetRandomEnemy();
            Instantiate(enemy, transform.position, transform.rotation);

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
