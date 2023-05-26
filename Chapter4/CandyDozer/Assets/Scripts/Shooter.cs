using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    const int MaxShotPower = 5;
    const int RecoverySeconds = 3;

    int shotPower = MaxShotPower;
    AudioSource shotSound;

    public GameObject[] candyPrefabs;
    public Transform candyParentTransform;
    public CandyManager candyManager;
    public float shotForce;
    public float shotTorque;
    public float baseWidth;
    // Start is called before the first frame update
    void Start()
    {
        shotSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) Shot();
    }
    //�L�����f�B�̃v���n�u���烉���_���ɂP�I��
    GameObject SampleCandy()
    {
        int index = Random.Range(0, candyPrefabs.Length);
        return candyPrefabs[index];
    }
    Vector3 GetInstantiatePosition()
    {
        //��ʃT�C�Y��Input�̊�������L�����f�B�����̃|�W�V�������v�Z
        float x = baseWidth * (Input.mousePosition.x / Screen.width) - (baseWidth / 2);
        return transform.position + new Vector3(x, 0, 0);
    }
    public void Shot()
    {
        //�L�����f�B�𐶐��ł�������O�Ȃ��Shot�͂��Ȃ�
        if (candyManager.GetCandyAmount() <= 0) return;
        if (shotPower <= 0) return;
        //�v���n�u����Candy�I�u�W�F�N�g�𐶐�
        GameObject candy = (GameObject)Instantiate(SampleCandy(),GetInstantiatePosition(),Quaternion.identity);
        //��������Candy�I�u�W�F�N�g�̐e��candyParentTransform�ɐݒ肷��
        candy.transform.parent = candyParentTransform;
        //Candy�I�u�W�F�N�g��Rigidbody���擾���͂Ɖ�]��������
        Rigidbody candyRigidbody = candy.GetComponent<Rigidbody>();
        candyRigidbody.AddForce(transform.forward * shotForce);
        candyRigidbody.AddTorque(new Vector3(0, shotTorque, 0));
        //Candy�̃X�g�b�N������
        candyManager.ConsumeCandy();
        //ShotPower������
        ConsumePower();
        //�T�E���h���Đ�
        shotSound.Play();
    }
    void OnGUI()
    {
        GUI.color = Color.black;
        //ShotPower�̎c�����{�̐��ŕ\��
        string label = "";
        for(int i = 0; i < shotPower; i++)
        {
            label = label + "+";
        }
        GUIStyle style = new GUIStyle();
        style.fontSize = 64;
        style.fontStyle = FontStyle.Bold;
        GUI.Label(new Rect(50, 115, 100, 30), label, style);
    }
    void ConsumePower()
    {
        //ShotPower�������Ɠ����ɉ񕜂̃J�E���g���X�^�[�g
        shotPower--;
        StartCoroutine(RecoverPower());
    }
    IEnumerator RecoverPower()
    {
        //���b���҂������Ƃ�shotPower����
        yield return new WaitForSeconds(RecoverySeconds);
        shotPower++;
    }
}