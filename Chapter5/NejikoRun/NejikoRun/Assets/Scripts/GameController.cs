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
        //�X�R�A���X�V
        int score = CalcScore();
        scoreText.text = "Score : " + score + "m";
        //���C�t�p�l�����X�V
        lifePanel.UpdateLife(nejiko.Life());
        //�˂��q�̃��C�t���O�ɂȂ����炰�[�ނ��[�΁[
        if (nejiko.Life() <= 0)
        {
            //����ȍ~��Update�͎~�߂�
            enabled = false;
            //�n�C�X�R�A���X�V
            if (PlayerPrefs.GetInt("HighScore") < score)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
            //�Q�b���ReturnToTitle���Ăяo��
            Invoke("ReturnToTitle", 2.0f);
        }
    }
    int CalcScore()
    {
        //�˂��q�̑��s�������X�R�A�Ƃ���
        return (int)nejiko.transform.position.z;
    }
    // Update is called once per frame
    void ReturnToTitle()
    {
        //�^�C�g���V�[���ɐ؂�ւ�
        SceneManager.LoadScene("Title");
    }
}
