using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restarter_on_Hit : MonoBehaviour
{
    [SerializeField] float reDelay=3f;
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            Invoke("restart",reDelay);
        }
    }

    void restart(){
        SceneManager.LoadScene(0);
        Debug.Log("hello");
    }
}
