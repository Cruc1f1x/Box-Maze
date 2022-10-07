using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike_collision : MonoBehaviour
{
    [SerializeField] ParticleSystem p_1;
    
    Rigidbody2D myRigidbody;
    
    SpriteRenderer[] sprites;

   [SerializeField] AudioClip deathSound;
  


    private void Start() {
        
        myRigidbody = GetComponent<Rigidbody2D>();
        sprites = GetComponentsInChildren<SpriteRenderer>();
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Spike"){
            
            Death();
            
        }
    }

      void   Death(){
                

                myRigidbody.simulated =false;
                
                 foreach(SpriteRenderer sprite in sprites) 
                    {
                            sprite.enabled = false;
                    }
                
                p_1.Play();
                GetComponent<AudioSource>().PlayOneShot(deathSound);
                


            }

            
            void OnTriggerExit2D(Collider2D other)
            {
                if(other.tag=="Escape line"){
                     myRigidbody.simulated =false;
                
                 foreach(SpriteRenderer sprite in sprites) 
                    {
                            sprite.enabled = false;
                    }
                }
            }
}
