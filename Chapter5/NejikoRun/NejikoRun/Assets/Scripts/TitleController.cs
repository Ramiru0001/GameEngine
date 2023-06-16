using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    public Text highScoreText;
    // Start is called before the first frame update
    public void Start()
    {
        //ハイスコアを表示
        highScoreText.text="High Score : " + PlayerPrefs.GetInt("HighScore")+"m";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Main");
    }
}
