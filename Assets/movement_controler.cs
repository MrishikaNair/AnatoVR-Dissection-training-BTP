using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_controler : MonoBehaviour
{

    public GameObject canvassss;
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        canvassss.transform.position = cam.transform.position;

    }
}
