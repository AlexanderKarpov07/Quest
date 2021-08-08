using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class people : MonoBehaviour
{

    private int a, b;
    public TextMesh text;
    public GameObject key;
    
    void Start()
    {
        a = Random.Range(0, 5);
        b = Random.Range(0, 5);
        text.text = a + " + " + b;
    }

    private void OnTriggerStay(Collider other)
    {
        int res;
        if (int.TryParse(Input.inputString, out res))
        {
            if (a + b == res)
            {
                var o = Instantiate(key, Vector3.one, Quaternion.identity);
                o.transform.position = new Vector3(890, 2, 384);
                o.transform.rotation = Quaternion.Euler(90,0,0);
            }
        }
    }

}
