using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCanon : MonoBehaviour
{
    public GameObject EnemyBullet;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("FireCanon", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FireCanon()
    {
        GameObject playerShip = GameObject.Find("Player");

        if(playerShip != null)
        {
            GameObject bullet = Instantiate(EnemyBullet);

            bullet.transform.position = transform.position;

            Vector2 direction = playerShip.transform.position - bullet.transform.position;

            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }
}
