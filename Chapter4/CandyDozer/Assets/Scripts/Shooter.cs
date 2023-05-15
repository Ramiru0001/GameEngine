using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject[] candyPrefabs;
    public Transform candyParentTransform;
    public float shotForce;
    public float shotTorque;
    public float baseWidth;
    // Start is called before the first frame update
    void Start()
    {
        
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
        //�v���n�u����Candy�I�u�W�F�N�g�𐶐�
        GameObject candy = (GameObject)Instantiate(SampleCandy(),GetInstantiatePosition(),Quaternion.identity);
        //��������Candy�I�u�W�F�N�g�̐e��candyParentTransform�ɐݒ肷��
        candy.transform.parent = candyParentTransform;
        //Candy�I�u�W�F�N�g��Rigidbody���擾���͂Ɖ�]��������
        Rigidbody candyRigidbody = candy.GetComponent<Rigidbody>();
        candyRigidbody.AddForce(transform.forward * shotForce);
        candyRigidbody.AddTorque(new Vector3(0, shotTorque, 0));
    }
}
