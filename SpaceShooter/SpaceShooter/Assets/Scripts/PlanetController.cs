using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public GameObject[] Planets;

    Queue<GameObject> availablePlanets = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        availablePlanets.Enqueue(Planets[0]);
        availablePlanets.Enqueue(Planets[1]);
        availablePlanets.Enqueue(Planets[2]);

        InvokeRepeating("MovingPlanet", 0f, 20f);
        //Invoke("MovingPlanet", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovingPlanet()
    {
        EnqueuePlanets();

        if (availablePlanets.Count == 0)
        {
            return;
        }
           
        GameObject planet = availablePlanets.Dequeue();

        planet.GetComponent<Planet>().isMoving = true;
    }

    public void EnqueuePlanets()
    {
        foreach(GameObject planet in Planets)
        {
            if ((planet.transform.position.y < 0) && (!planet.GetComponent<Planet>().isMoving))
            {
                planet.GetComponent<Planet>().ResetPlanetPosition();

                availablePlanets.Enqueue(planet);
            }
        }
    }
}
