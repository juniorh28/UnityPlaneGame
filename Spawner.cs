using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject coin;
    const int NUM_COINS = 10;
    // Start is called before the first frame update
    void Start()
    {
        Spawn2();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn1()
    //draw a giant bounding box and randomly create coins anywhere within the box
    {
        int xMin = -5;
        int xMax = 15;
        int yMin = 2;
        int yMax = 5;

        for (int i = 0; i < NUM_COINS; i++)
        {
            Vector2 position = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            Instantiate(coin, position, Quaternion.identity);
        }

    }

    void Spawn2()
    //create a first coin and then create subsequent coins with random offsets from the first one
    {
        Vector2 position = new Vector2(-3, 5);
        for (int i = 0; i < NUM_COINS; i++)
        {
            Instantiate(coin, position, Quaternion.identity);
            position = new Vector2(position.x + Random.Range(-5, 15), position.y + Random.Range(-2, 2));
        }
    }
}
