using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunGO : MonoBehaviour
{
    public GameObject EnemyBulletGO;
    // Start is called before the first frame update
    void Start()
    {
        Invoke ("Fire" ,1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Fire()
    {
            GameObject bullet = (GameObject)Instantiate(EnemyBulletGO);

            bullet.transform.position = transform.position;

    }
}
