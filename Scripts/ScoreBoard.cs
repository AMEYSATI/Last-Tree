using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreBoard : MonoBehaviour
{
    int score;
    [SerializeField] int maxscore = 15;
    int nextlevel = 1;
    [SerializeField] int loadelay = 1;

    TMP_Text scoretext;

     void Start()
    {
        scoretext = GetComponent<TMP_Text>();
        scoretext.text = "0";
    }

    public void increasescore(int s)
    {
        score += s;
       scoretext.text = score.ToString();
        if(score >= maxscore)
        {
            Invoke("nextlevelscene", loadelay);
        }
    }

   void nextlevelscene()
    {
        SceneManager.LoadScene(nextlevel);
        nextlevel++;
    }
}
