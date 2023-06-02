using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    }
    int CalcScore()
    {
        //ねじ子の走行距離をスコアとする
        return (int)nejiko.transform.position.z;
    }
    // Update is called once per frame
}
