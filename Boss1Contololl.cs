using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1Contololl : MonoBehaviour
{
    // Start is called before the first frame update
    private float Tairyoku = 100;
    int m_count;
    public GameObject TamaPrefab;

    [SerializeField]private GameObject Player;

    public GameObject BossProjectilePrefab;
    public float interval = 2.0f;
    public Text TairyokuGage;
    [SerializeField] private Text GameOverText;

    public int speed = 5; //動く速度
    Vector3 movePosition;//目的地保存

      private AudioSource audioSource;
    public AudioClip overSound;


    void Start()
    {
        PikUpGage();
        StartCoroutine("Utu");
        movePosition = moveRandomPosition();
        GameOverText.enabled = false;
       
    }
    private Vector3 moveRandomPosition()
    {
        Vector3 randomPosi = new Vector3(this.gameObject.transform.position.x, Random.Range(-4,4));
        return randomPosi;
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tama")
        {
            
            Tairyoku -= 10;
            PikUpGage();
         
        }
        if (Tairyoku <= 0)
        {
            Tairyoku = 0;
            PikUpGage();
          

            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (movePosition == BossProjectilePrefab.transform.position)
        {
            movePosition = moveRandomPosition();

        }
        this.BossProjectilePrefab.transform.position = Vector3.MoveTowards(BossProjectilePrefab.transform.position, movePosition, speed * Time.deltaTime);
        if (Player == null)
        {
            GameOverText.enabled = true;
        }
    }
    IEnumerator Utu()
    {
        //無限ループの開始
        while (true)
        {
            //自分をつけたオブジェクトの位置に、発生するオブジェクトをインスタンス化して生成する
            Instantiate(TamaPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(interval);

        }
    }
    private void PikUpGage()
    {
        TairyokuGage.text = "中三のガキ　体力："+Tairyoku.ToString();
    }






}
