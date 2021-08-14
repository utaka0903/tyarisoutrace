using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverSceneManager : MonoBehaviour
{
    //private float result;
    public Text ResultText; 
    public GameObject StartSound;
    // Start is called before the first frame update
    void Start()
    {
        //result = PlayerPrefs.GetFloat("FinalScore");
        ResultText.text = PlayerPrefs.GetFloat("FinalScore").ToString("F2") + "m";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickToTitleButton()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void OnClickToMainButton()
    {
        SceneManager.LoadScene("MainScene");
        GameObject StartSoundclone = Instantiate(StartSound);
        Destroy(StartSoundclone,3.0f);
    }
}
