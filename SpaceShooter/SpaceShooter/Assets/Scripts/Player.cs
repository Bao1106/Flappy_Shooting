using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject GameManager;

    public GameObject PlayerCanon;
    public GameObject BulletLeftCanon;
    public GameObject BulletRightCanon;
    public GameObject Explosion;

    public Text PlayerLivesText;

    public const int maxLives = 3;
    public int playerLive;

    public float speed;

    public void Init()
    {
        playerLive = maxLives;
        PlayerLivesText.text = playerLive.ToString();
        transform.position = new Vector2(0, 0);
        gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<AudioSource>().Play();

            Fire();
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 direction = transform.position;

        direction.x = direction.x + speed * x * Time.deltaTime;
        direction.y = direction.y + speed * y * Time.deltaTime;

        transform.position = direction;

        //Move(direction);
    }

    //void Move(Vector2 direction)
    //{
    //    Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
    //    Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

    //    max.x = max.x - 0.885f;
    //    min.x = min.x + 0.885f;

    //    max.y = max.y - 0.814f;
    //    min.y = min.y + 0.814f;

    //    Vector2 pos = transform.position;

    //    pos += pos * speed * Time.deltaTime;

    //    pos.x = Mathf.Clamp(pos.x, min.x, max.x);
    //    pos.y = Mathf.Clamp(pos.x, min.y, max.y);

    //    transform.position = pos;
    //}

    void Fire()
    {
        GameObject BulletLeft = Instantiate(PlayerCanon);
        BulletLeft.transform.position = BulletLeftCanon.transform.position;

        GameObject BulletRight = Instantiate(PlayerCanon);
        BulletRight.transform.position = BulletRightCanon.transform.position;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.tag == "EnemyShip") || (collision.tag == "EnemyBullet"))
        {
            ExplosionEffect();
            playerLive--;
            PlayerLivesText.text = playerLive.ToString();

            if(playerLive == 0)
            {
                GameManager.GetComponent<GameManager>().SetManagerState(global::GameManager.ManagerState.GameOver);

                Destroy(gameObject);
            }            
        }    
    }

    public void ExplosionEffect()
    {
        GameObject explosion = Instantiate(Explosion);
        explosion.transform.position = transform.position;
    }
}
