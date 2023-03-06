using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;

  public Transform shottingOffset;

  public float speed = 500f;
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
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        Debug.Log("Bang!");

        Destroy(shot, 3f);

      }
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //   Debug.Log("Entered");
    //   if (other.gameObject.name is not "EnemyBullet(Clone)") return;
    //   Debug.Log("Player Hit!");
    //   Destroy(other.gameObject);
    // }
}
