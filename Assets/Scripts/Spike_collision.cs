using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike_collision : MonoBehaviour
{
    [SerializeField] ParticleSystem p_1;
    // [SerializeField] float deathDelay =2f;
    Rigidbody2D myRigidbody;
    
    SpriteRenderer[] sprites;
  


    private void Start() {
        // GetComponent<ParticleSystem>();
        // playerSprite= GetComponentInChildren<SpriteRenderer> ();
        myRigidbody = GetComponent<Rigidbody2D>();
        sprites = GetComponentsInChildren<SpriteRenderer>();
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Spike"){
            // StartCoroutine(Death());
            Death();
            // SceneManager.LoadScene(0);
        }
    }

      void   Death(){
                

                myRigidbody.simulated =false;
                
                 foreach(SpriteRenderer sprite in sprites) 
                    {
                            sprite.enabled = false;
                    }
                
                p_1.Play();

                // yield return new WaitForSeconds(deathDelay);

                // Destroy(gameObject);


            }
}
