using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHit : MonoBehaviour
{
    [SerializeField] int hitpointplayer = 1;
    [SerializeField] Transform parent;
    [SerializeField]GameObject playerhit;
    [SerializeField] GameObject playerexplosion;
    int i = 100;
    int loadelay = 1;

    PlayerHealth health;

    // Start is called before the first frame update
    void Start()
    {
        health = FindObjectOfType<PlayerHealth>();
    }
    void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "laser")
        {
            playerhitpoint();
            if (i < 1)
            {
                killplayer();
            }
        }
    }
    void playerhitpoint()
    {
        GameObject exp = Instantiate(playerhit, transform.position, Quaternion.identity);
        exp.transform.parent = parent;
        i--;
        hitscore();
    }
    void killplayer()
    {
        GameObject exp = Instantiate(playerexplosion, transform.position, Quaternion.identity);
        exp.transform.parent = parent;
        GetComponent<Movement>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        Invoke("ReloadScene", loadelay);

    }
    void hitscore()
    {
        health.decreasehealth(hitpointplayer);
    }
    void ReloadScene()
    {
        int activescene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activescene);
    }

}
