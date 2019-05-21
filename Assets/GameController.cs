using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public static GameController game { get; set; }

    public List<int> resultSprite;

    private int score;

    private void Awake()
    {
        game = this;

        resultSprite = new List<int>();

        score = 0; 
    }
   
    public void Display()
    {
        if (CheckAlignment())
        {
            score += 20;
        }
        if (CheckTriangle())
        {
            score += 50;
        }
        DestroyElenment();

    }
    private bool CheckAlignment()
    {
        if (resultSprite[0] == resultSprite[3] && resultSprite[0] == resultSprite[6]
                 || resultSprite[1] == resultSprite[4] && resultSprite[1] == resultSprite[7]
                 || resultSprite[2] == resultSprite[5] && resultSprite[0] == resultSprite[8])
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private bool CheckTriangle()
    {
        if (resultSprite[1] == resultSprite[5] && resultSprite[1] == resultSprite[7]
               || resultSprite[1] == resultSprite[3] && resultSprite[1] == resultSprite[7])
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void DestroyElenment()
    {
        for (int i = 0; i < resultSprite.Count; )
        {
            resultSprite.RemoveAt(i);
        }
    }
   
}
