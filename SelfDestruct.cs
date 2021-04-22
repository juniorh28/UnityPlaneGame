using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{

    public float timer = 5f;
    // Start is called before the first frame update
    void Start()
    {
        timer -= Time.deltaTime;

        if(timer <=0){
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
