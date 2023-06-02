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
        //�X�R�A���X�V
        int score = CalcScore();
        scoreText.text = "Score : " + score + "m";
        //���C�t�p�l�����X�V
        lifePanel.UpdateLife(nejiko.Life());
    }
    int CalcScore()
    {
        //�˂��q�̑��s�������X�R�A�Ƃ���
        return (int)nejiko.transform.position.z;
    }
    // Update is called once per frame
}
