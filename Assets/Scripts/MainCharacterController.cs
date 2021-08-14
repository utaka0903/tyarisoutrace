using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCharacterController : MonoBehaviour
{
    // [SerializeField] float MoveSpeed = 1.0f;
    // [SerializeField] float JumpHeight = 1.0f;
    private bool playerisGrounded = true;
    [SerializeField] float jumpSpeed = 1.0f;
    float Timer = 0.0f;
    private float score = 0;
    public int scoreNumber = 10;
    float scoreisnotStop = 1.0f;
    Rigidbody2D myrigid;
    //private int jumpCounter = 0;
    [SerializeField] float playerSpeed = 1.0f;//cameracontrollerのcameraspeedと同じにする
    [SerializeField] float PositionY = -6.0f;
    Transform playerPosition;
    public GameObject jumpSound;
    public GameObject fallSound;
    // Start is called before the first frame update
    void Start()
    {
        myrigid = this.GetComponent<Rigidbody2D>();
        scoreisnotStop = 1.0f;
        Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime * scoreisnotStop;
        score = Timer * scoreNumber;
        this.transform.position += transform.right * playerSpeed * Time.deltaTime;
        playerPosition = this.transform;
        Move();
        ToGameOverScene();
    }

    void Move()
    {
        //this.transform.position += transform.right * MoveSpeed;
        if(Input.GetMouseButtonDown(0) && playerisGrounded == true)//firstjump
        {
            myrigid.AddForce(transform.up * jumpSpeed, ForceMode2D.Impulse);
            playerisGrounded = false;
            //Debug.Log("playerisGrounded =" + playerisGrounded);
            GameObject jumpSoundclone = Instantiate(jumpSound);
            Destroy(jumpSoundclone,3.0f);
        }
        if(Input.GetMouseButtonDown(0) && playerisGrounded == false)//secondjump
        {
            myrigid.AddForce(transform.up * jumpSpeed * 0.5f, ForceMode2D.Impulse);
            GameObject jumpSoundclone = Instantiate(jumpSound);
            Destroy(jumpSoundclone,3.0f);
        }
    }

    

    void OnCollisionStay2D(Collision2D collision)//2段ジャンプ実装用
    {
        if(collision.gameObject.tag == "Ground")
        {
            playerisGrounded = true; 
            //Debug.Log("playerisGrounded = " + playerisGrounded);
        }else//それ以外のものに触れた時という意味になる
        {
            playerisGrounded = false; 
        }
    }
    void ToGameOverScene()
    {
        if(playerPosition.position.y < PositionY)//完全に落ちた時
        {
            scoreisnotStop = 0;//scoreのカウントを止める
            PlayerPrefs.SetFloat("FinalScore", score);
            SceneManager.LoadScene("GameOverScene");
        }
        if(playerPosition.position.y < PositionY + 3.0f)//半分落ちた時
        {
            playerSpeed = 0;
            GameObject fallSoundclone = Instantiate(fallSound);
            Destroy(fallSoundclone,3.0f);
        }
    }
    
}
