using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
  
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("スコア");
        //var score = GameObject.FindGameObjectWithTag("Animals").GetComponent<ScoreKanro>();
        //score.SetScoreText(score.plusscore());
        Destroy(gameObject);
        Destroy(collision.gameObject);
        Debug.Log("壊れた");

    }
}
