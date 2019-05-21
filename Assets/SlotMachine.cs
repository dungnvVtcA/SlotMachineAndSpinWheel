using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachine : MonoBehaviour
{

    public Reel[] reel;

    bool startSpin;

   
    void Start()
    {
        startSpin = false;
    }

  
    void Update()
    {
        if (!startSpin)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                startSpin = true;
                StartCoroutine(Spinning());
            }
        }
    }

    IEnumerator Spinning()
    {
        foreach (Reel spinner in reel)
        {
            
            spinner.spin = true;
        }

        for (int i = 0; i < reel.Length; i++)
        {
           
            yield return new WaitForSeconds(Random.Range(1, 3));

            reel[i].spin = false;

            reel[i].RandomPosition();

            //Debug.Log(reel[i].transform.GetChild(2).gameObject.GetComponent<UnityEngine.UI.Image>().sprite.name);

        }
        for (int i = 0; i < 6; i++)
        {
            if (reel[1].transform.GetChild(i).gameObject.GetComponent<UnityEngine.UI.Image>().transform.position.y == 960)
            {
                Debug.Log(reel[1].transform.GetChild(i).gameObject.GetComponent<UnityEngine.UI.Image>().sprite.name);
            }
        }

        startSpin = false;
    }
}