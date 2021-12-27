using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamaContllor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject particleObject;
    private AudioSource audioSource;
    public AudioClip Atattaoto;



    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Boss1")
        {
            Instantiate(particleObject, this.transform.position, Quaternion.identity); //パーティクル用ゲームオブジェクト生成
            audioSource.PlayOneShot(Atattaoto);
            Debug.Log("当たった");

           // Destroy(this.gameObject); //衝突したゲームオブジェクトを削除
        }
    }

    
  

 

    // Update is called once per frame
    void Update()
    {
        
    }
}
