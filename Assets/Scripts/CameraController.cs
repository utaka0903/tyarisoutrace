using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    // [SerializeField] float cameraSpeeed = 1.0f;
    //Vector2 playervector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position += transform.right * cameraSpeeed * Time.deltaTime;
        this.transform.position = new Vector3(player.transform.position.x,this.transform.position.y,-10);//z座標のところはthis.transform.position.zにするとエラー
         
    }
}
