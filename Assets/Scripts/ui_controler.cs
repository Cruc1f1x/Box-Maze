using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ui_controler : MonoBehaviour
{
    [SerializeField] AudioClip buttonSelect;
    [SerializeField] float delayForSound = 0.5f;

    public void Play(){
        GetComponent<AudioSource>().PlayOneShot(buttonSelect);
        Invoke("startlevel",delayForSound);
    }

    public void Quit(){
        GetComponent<AudioSource>().PlayOneShot(buttonSelect);
        Invoke("endGame",delayForSound);
        Debug.Log("quit");
    }

    void startlevel(){
                SceneManager.LoadScene(1);

    }

    void endGame(){
        Application.Quit();
    }

}
