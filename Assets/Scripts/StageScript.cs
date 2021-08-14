using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScript : MonoBehaviour
{
    [SerializeField] GameObject[] stages = new GameObject[5];
    public GameObject player;
    Transform playerPosition;
    GameObject stageclone;
    Transform stageclonePosition;
    int stageNumber;
    float height; 
    [SerializeField] float minheight = -5;
    [SerializeField] float maxheight = 5;
    [SerializeField] float minposition = -5;
    [SerializeField] float maxposition = 5;
    [SerializeField] float stagePosition = 10.0f;
    private float positionparameter;


    //private float respawn = 30.0f;
    private float timecounter = 0;
    private float timer = 0;
    [SerializeField] float respawnterm = 1.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        playerPosition = player.transform;
        if(timecounter > respawnterm)
        {
            timecounter = 0;
            StageInstantiate();   
        }else
        {
            timecounter += Time.deltaTime;
        }
        // if(stageclonePosition.position.x < playerPosition.position.x)
        // {
        //     Destroy(stageclone);
        // }

    }

    int GetRandomNumber(int m)
    {
        m = Random.Range(0,5);
        Debug.Log("stageNumber = " + m);
        return m;
    }

    float GetHeight(float n)
    {
        n = Random.Range(minheight, maxheight);
        return n;
    }

    float GetfloatNumber(float p, float min, float max)
    {
        p = Random.Range(min, max);
        return p;
    }

    void StageInstantiate()
    {
        stageNumber = GetRandomNumber(stageNumber);
        height = GetHeight(height);
        positionparameter = GetfloatNumber(positionparameter, minposition, maxposition);
        stageclone = Instantiate(stages[stageNumber], new Vector2(timer * stagePosition + positionparameter, -3 + height), Quaternion.identity);//Quaternion.identityがないとエラー出た
        //stageclonePosition = stageclone.transform;
        Destroy(stageclone, 20.0f);
        Debug.Log("stageInstantiate");
    }
}
