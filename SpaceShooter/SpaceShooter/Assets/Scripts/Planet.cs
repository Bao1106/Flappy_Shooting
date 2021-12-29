using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float speed;
    public bool isMoving;

    Vector2 min, max;

    private void Awake()
    {
        isMoving = false;

        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //add planet sprite half height to max y
        max.y = max.y + GetComponent<SpriteRenderer>().sprite.bounds.extents.y;

        //subtract planet sprite half height to min y
        min.y = min.y - GetComponent<SpriteRenderer>().sprite.bounds.extents.y;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
            return;

        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        transform.position = position; 

        if (transform.position.y < min.y) 
        {
            isMoving = false;
        }
    }

    public void ResetPlanetPosition()
    {
        //min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
    }
}
