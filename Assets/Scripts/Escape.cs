using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour
{
    [SerializeField] AudioClip levelChanger;
    [SerializeField] float sceneChangeDelay = 2f;
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player"){

            // SceneManager.LoadScene(0);
            GetComponent<AudioSource>().PlayOneShot(levelChanger);
            Invoke("changescene",sceneChangeDelay);
        }
    }

    void changescene(){
        SceneManager.LoadScene(0);
    }
}
