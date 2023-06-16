using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public NejikoController nejiko;
    public TextMeshProUGUI scoreText;
    public LifePanel lifePanel;
    // Start is called before the first frame update
    void Update()
    {
        //スコアを更新
        int score = CalcScore();
        scoreText.text = "Score : " + score + "m";
        //ライフパネルを更新
        lifePanel.UpdateLife(nejiko.Life());
        //ねじ子のライフが０になったらげーむおーばー
        if (nejiko.Life() <= 0)
        {
            //これ以降のUpdateは止める
            enabled = false;
            //ハイスコアを更新
            if (PlayerPrefs.GetInt("HighScore") < score)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
            //２秒後にReturnToTitleを呼び出す
            Invoke("ReturnToTitle", 2.0f);
        }
    }
    int CalcScore()
    {
        //ねじ子の走行距離をスコアとする
        return (int)nejiko.transform.position.z;
    }
    // Update is called once per frame
    void ReturnToTitle()
    {
        //タイトルシーンに切り替え
        SceneManager.LoadScene("Title");
    }
}
