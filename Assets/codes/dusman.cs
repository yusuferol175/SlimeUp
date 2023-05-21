using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dusman : MonoBehaviour
{
    private float x_sol;
    private float x_sag;
    private float x_deger=1f;
    private GameObject nesne;
    
   
    void Start()
    {
        nesne = gameObject;
        x_sag = nesne.transform.position.x + 1.7f;
        x_sol = nesne.transform.position.x - 1.7f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nesne.gameObject)
        {
            if (transform.position.x>x_sag && x_deger > 0)
            {
                x_deger = x_deger * -1f;
            }
            if (transform.position.x < x_sol&& x_deger<0)
            {
                x_deger = x_deger * -1f;
            }


              nesne.transform.position = new Vector3(nesne.transform.position.x + 3.5f * Time.deltaTime*x_deger, nesne.transform.position.y, nesne.transform.position.y);
            
            
        }
        
    }
}
