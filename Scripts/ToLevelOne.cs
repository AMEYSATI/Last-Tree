using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevelOne : MonoBehaviour
{
    [SerializeField] int sceneload = 1;
    // Update is called once per frame
   public void Start()
    {
        SceneManager.LoadScene(sceneload);
    }
}
