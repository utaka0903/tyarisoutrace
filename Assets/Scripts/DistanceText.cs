using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceText : MonoBehaviour
{
    float Timer = 0.0f;
    public int scoreNumber = 10;
    private float score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        score = Timer * scoreNumber;
        GetComponent<Text>().text = score.ToString("F2") + "m";
    }
}
