using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] float reloadTime = 2f;
    [SerializeField] ParticleSystem particleEffect;
    [SerializeField] AudioClip crashSFX; // audioclip untuk play banyak SFX berbeda beda
    bool hasCrash = false; // ini untuk play SFX 1x saja (kalau kena ground 2x)
  private void OnTriggerEnter2D(Collider2D other) 
  {
    if(other.tag == "Ground" && !hasCrash)
    {
      hasCrash = true;
        FindObjectOfType<PlayerController>().DisableControls();
        particleEffect.Play();
        GetComponent<AudioSource>().PlayOneShot(crashSFX);
        Invoke("ReloadScene", reloadTime);
    }
  }

  void ReloadScene()
  {
    SceneManager.LoadScene(0);
  }
}
