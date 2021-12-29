using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public GameObject Explosion;
    GameObject ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3f;

        ScoreText = GameObject.FindGameObjectWithTag("Score");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.tag == "PlayerShip") || (collision.tag == "PlayerBullet"))
        {
            EnemeyExplosion();

            ScoreText.GetComponent<PlayerScore>().Score += 100;

            Destroy(gameObject);
        }
    }

    public void EnemeyExplosion()
    {
        GameObject explosion = Instantiate(Explosion);
        explosion.transform.position = transform.position;
    }
}
