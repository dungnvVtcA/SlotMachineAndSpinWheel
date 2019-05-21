using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWheel : MonoBehaviour
{
    private float t;

    private float dr;

    private int[] arrMilestone = { 30, 90, 120 , 210 , 270 };

    int rand;
   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {

            rand = Random.Range(0, arrMilestone.Length);
            Debug.Log(rand);
            Genarator(arrMilestone[rand]);

       
        }
        transform.eulerAngles += new Vector3(0, 0, t);
        t -= dr;
        if (t < 0)
        {

            t = 0;

            transform.eulerAngles += new Vector3(0, 0, transform.eulerAngles.z - (transform.eulerAngles.z / 360) * 360);

        }
    }

    private void Genarator(float r)
    {
        // spin in 5s
        float d = 360 * 5 + r - transform.eulerAngles.z;
        float f = 0.0f;
        for( int i = 0; i <= 5 * 60; i++)
        {
            f += i;
        }
        dr = d / f;

        t = 5 * 60 * dr;
    }
}
