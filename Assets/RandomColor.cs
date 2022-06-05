using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    public Material[] material;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        gameObject.GetComponent<Renderer>().material = material[Random.Range(0, 4)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
