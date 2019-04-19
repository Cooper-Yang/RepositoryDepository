using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    // Start is called before the first frame update
    public int p1Score;
    public int p2Score;

    public TextMesh p1Text;
    public TextMesh p2Text;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        p1Text.text = p1Score.ToString();
        p2Text.text = p2Score.ToString();
    }
}
