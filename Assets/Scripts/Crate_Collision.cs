using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Crate_Collision : MonoBehaviour
{

[SerializeField] AudioClip bumpSound;
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player")
        GetComponent<AudioSource>().PlayOneShot(bumpSound);
    }
}
