using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreIncrementer : MonoBehaviour
{
    public bool p1;
    public ScoreKeeper scoreKeeper;
    public Ball theBall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (p1)
            scoreKeeper.p1Score++;
        else
            scoreKeeper.p2Score++;
        theBall.Reset();
    }


}
