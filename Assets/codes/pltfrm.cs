using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pltfrm : MonoBehaviour
{
    private float y_ust;
    private float y_alt;
    private float y_deger = 1f;
    private GameObject nesne;
    // Start is called before the first frame update

    
    void Start()
    {
        nesne = gameObject;
        y_ust = nesne.transform.position.y + 2f;
        y_alt = nesne.transform.position.y - 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (nesne.gameObject)
        {
            if (transform.position.y > y_ust && y_deger > 0)
            {
                y_deger = y_deger * -1f;
            }
            if (transform.position.y < y_alt && y_deger < 0)
            {
                y_deger = y_deger * -1f;
            }


            nesne.transform.position = new Vector3(nesne.transform.position.x, nesne.transform.position.y + 3.5f * Time.deltaTime * y_deger, nesne.transform.position.y);


        }

    }
}

