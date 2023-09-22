using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] float loadelay = 1f;
    [SerializeField] ParticleSystem explosion;

    void OnCollisionEnter(Collision collision)
    {
        explosion.Play();
        GetComponent<Movement>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
       // Destroy(gameObject);
        Invoke("ReloadScene", loadelay);
    }
    void ReloadScene()
    {
        int activescene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activescene);
    }
}
