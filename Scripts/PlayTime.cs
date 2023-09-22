using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayTime : MonoBehaviour
{
    float seconds = 0;
    [SerializeField] int timelimit = 90;
   [SerializeField]int loadelay = 1;

    TMP_Text timetext;
    // Start is called before the first frame update
    void Start()
    {

        timetext = GetComponent<TMP_Text>();
        timetext.text = "300";
    }

    // Update is called once per frame
    void Update()
    {
        timelapsed();
    }

    void timelapsed()
    {
        seconds =(int) Time.timeSinceLevelLoad;
        timetext.text = seconds.ToString();
        if(seconds >= timelimit)
        {
            Invoke("reloadscene", loadelay);
        }
    }

     void reloadscene()
    {
        int activescene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activescene);
    }
}
