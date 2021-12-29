using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipes : MonoBehaviour
{
    public float queueTime = 1.5f;   
    public GameObject obstacle;
    public float height;

    private float time = 0;

    void Start()
    {
        //StartCoroutine(Update());
        GameObject newPipe = Instantiate(obstacle);
        newPipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);

    }

    //IEnumerator Update()
    //{
    //    yield return new WaitForSeconds(5);

    //    Instantiate(obstacle, new Vector3(0, Random.Range(-height, height), 0), Quaternion.identity);

    //    StartCoroutine(Update());
    //}

    void Update()
    {
        if (time > queueTime) 
        {
            GameObject go = Instantiate(obstacle);
            go.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);

            time = 0;

            Destroy(go, 10);
        }
        time += Time.deltaTime;
    }
}
