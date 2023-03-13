using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
  public GameObject bullet;

  public Transform shottingOffset;

  public float speed = 0.00001f;

  public AudioSource explosion;

  private AudioSource shootSound;

  private Animator playerAnimator;
  
  public AudioSource backgroundMusic;
  private void Start()
  {
    shootSound = GetComponent<AudioSource>();
    playerAnimator = GetComponent<Animator>();
    backgroundMusic.Play();
  }

  // Update is called once per frame
    void Update()
    {

      if (Input.GetKey(KeyCode.D))
      {
        transform.Translate(speed * Time.deltaTime, 0, 0);
      } else if (Input.GetKey(KeyCode.A))
      {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
      }

      if (Input.GetKeyDown(KeyCode.Space))
      {
        playerAnimator.SetTrigger("isShooting");
        shootSound.Play();
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        Debug.Log("Bang!");

        Destroy(shot, 3f);

      }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
      if (col.gameObject.name is "EnemyBullet(Clone)")
      {
        explosion.Play();
        playerAnimator.SetTrigger("isDead");
        Debug.Log("Player Died! Restart Game to try again.");
        Destroy(col.gameObject, 2f);
        Invoke(nameof(GoToCredits), 1);
      }
    }

    private void GoToCredits()
    {
      SceneManager.LoadScene("CreditScene", LoadSceneMode.Single);
    }
}
