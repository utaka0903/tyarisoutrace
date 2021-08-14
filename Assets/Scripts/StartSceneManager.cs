using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartSceneManager : MonoBehaviour
{
    //public Text lastScoreText;
    public Text highScoreText;
    float highScore;
    float lastScore;
    public GameObject StartButtonSound;
    // Start is called before the first frame update

    void Start()
    {
        lastScore = PlayerPrefs.GetFloat("FinalScore");
        //lastScoreText.text = lastScore.ToString();

        if(PlayerPrefs.HasKey("highScore") == true)//highScoreというデータが保存されていたら
        {
            highScore = PlayerPrefs.GetFloat("highScore");
            if(highScore < lastScore)//highScoreを更新するとき
            {
                highScore = lastScore;
                PlayerPrefs.SetFloat("highScore",highScore);
            }
        }else//highScoreが登録されていない時
            {
                highScore = lastScore;
                PlayerPrefs.SetFloat("highScore", highScore);
            }
            highScoreText.text = highScore.ToString("F2") + "m";
        
    }

    
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("MainScene");
        GameObject StartButtonSoundclone = Instantiate(StartButtonSound);
        Destroy(StartButtonSoundclone,3.0f);
    }    


}
