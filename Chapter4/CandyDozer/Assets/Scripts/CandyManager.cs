using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
public class CandyManager : MonoBehaviour
{
    const int  DefaultCandyAmount = 30;
    const int RecoverySeconds = 10;
    //���݂̃L�����f�B�X�g�b�N��
    public int candy = DefaultCandyAmount;
    //�X�g�b�N�񕜂܂ł̎c��b��
    int counter;
    public void ConsumeCandy()
    {
        if (candy > 0) candy--;
    }
    public int GetCandyAmount()
    {
        return candy;
    }
    public void AddCandy(int amount)
    {
        candy += amount;
    }
    void OnGUI()
    {
        GUI.color = Color.black;
        //�L�����f�B�̃X�g�b�N����\��
        string label = "Candy : " + candy;
        GUIStyle style = new GUIStyle();
        style.fontSize = 64;
        style.fontStyle = FontStyle.Bold;
        //�񕜃J�E���g���Ă���Ƃ������b����\��
        if (counter > 0) label = label + "(" + counter + "s)";
        GUI.Label(new Rect(50, 50, 100, 30), label,style);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�L�����f�B�̃X�g�b�N���f�t�H���g��菭�Ȃ�
        //�񕜃J�E���g�����Ă��Ȃ��Ƃ��ɃJ�E���g���X�^�[�g������
        if(candy<DefaultCandyAmount && counter <= 0)
        {
            StartCoroutine(RecoverCandy());
        }
    }
    IEnumerator RecoverCandy()
    {
        counter = RecoverySeconds;
        //1�b���J�E���g��i�߂�
        while(counter > 0){
            yield return new WaitForSeconds(1.0f);
            counter--;
        }
        candy++;
    }
}
