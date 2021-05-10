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
        int xMin = -41;
        int xMax = 41;
        int yMin = -16;
        int yMax = 16;
    void Spawn1()
    //draw a giant bounding box and randomly create coins anywhere within the box
    {
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
            position = new Vector2(position.x + Random.Range(xMin, xMax), position.y + Random.Range(yMin, yMax));
        }
    }
}
