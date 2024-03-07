using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float reloadTime = 2f;
    [SerializeField] ParticleSystem particleEffect;
   private void OnTriggerEnter2D(Collider2D other) 
   {
    
    if(other.tag == "Player")
    {
        particleEffect.Play();
        GetComponent<AudioSource>().Play();
        Invoke("ReloadScene", reloadTime);
    }
   }
   void ReloadScene()
   {
    SceneManager.LoadScene(0);
   }

}
