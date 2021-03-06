using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = -8f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y + speed * Time.deltaTime);


        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if ((transform.position.y > max.y)|| (transform.position.y < min.y))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerShipTag")
        {
            Destroy(gameObject);
        }
    }
}
