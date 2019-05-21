using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpriteRandom : MonoBehaviour
{
    public Sprite[] sprites;

    public float TimeStop;

    private float timeRun;

    private bool  isSpin = true;

    private void Start()
    {
        enabled = false;


    }
    void Update()
    {
       
        RandomImages();
        if (timeRun >= 5)
        {
            this.StopGame();
            timeRun = 0;
        }
        timeRun += Time.deltaTime;
    }
    void RandomImages()
    {
        gameObject.GetComponent<UnityEngine.UI.Image>().sprite = sprites[Random.Range(0, sprites.Length)];
    }
    void StartGame()
    {
        if (isSpin)
        {
            enabled = true;
            timeRun = 0f;
            isSpin = false;
            
        }


    }
    public void EndGame()
    {
        enabled = false;
        //Debug.Log(gameObject.GetComponent<UnityEngine.UI.Image>().sprite.GetInstanceID() + " " + gameObject.name);
        var ID = gameObject.GetComponent<UnityEngine.UI.Image>().sprite.GetInstanceID();
        GameController.game.resultSprite.Add(ID);
        if(GameController.game.resultSprite.Count == 9)
        {
            GameController.game.Display();
        }
    }
    public void StopGame()
    {

        Invoke("EndGame", TimeStop);

        if(TimeStop == 1)
        {
            Invoke("Delay", 3);
        }
        if (TimeStop == 2)
        {
            Invoke("Delay", 2);
        }
        if (TimeStop == 3)
        {
            Invoke("Delay", 1);
        }


    }
    public void Delay()
    {
        isSpin = true;
    }
}
