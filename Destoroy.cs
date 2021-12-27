using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destoroy : MonoBehaviour
{
    private float topBound = 15;
    private float lowerBound = -15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x > topBound || transform.position.x < lowerBound)
        {
            Destroy(gameObject);
        }
    }
}
