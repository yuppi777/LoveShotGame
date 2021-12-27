using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControll : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10.0f;
    public float xRange = 10;
    private float PlayerTairyoku = 100;

    public GameObject projectilePrefab;

    public Text textClear;

    public Text PlayerTairyokuGage;

    public GameObject Boss;

    public Transform Playerzn;
    public float Playerz;
    void Start()
    {
        PikUpGage();

        Playerz = Playerzn.position.z;

        textClear.enabled = false;
       
    }

   
    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector2.up * horizontalInput * Time.deltaTime * speed); //プレイヤーが動く

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }

        if (Boss == null)
        {
            textClear.enabled = true;
        }
        GameObject targetObj = GameObject.FindWithTag("Boss1");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tama2")
        {

            PlayerTairyoku -= 30;

            PikUpGage();
        }
        if (PlayerTairyoku<= 0)
        {
            PlayerTairyoku = 0;
            PikUpGage();
            Destroy(gameObject);
        }
    }
    private void PikUpGage()
    {
        PlayerTairyokuGage.text = "チー牛の俺　体力：" + PlayerTairyoku.ToString();
    }
}
