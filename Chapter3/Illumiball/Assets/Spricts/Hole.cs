using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    //�ǂ̃{�[�����z���񂹂邩�^�O�Ŏw��
    public string targetTag;
    bool isHolding;

    //�{�[���������Ă��邩��n��
    public bool IsHolding()
    {
        return isHolding;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {
            isHolding = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {
            isHolding = false;
        }
    }
    void OnTriggerStay(Collider other)
    {
        //�R���C�_�ɐG��Ă���I�u�W�F�N�g��Rigidbody�R���|�[�l���g���擾
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();
        //�{�[�����ǂ̕����ɂ��邩���v�Z
        Vector3 direction = other.gameObject.transform.position - transform.position;
        direction.Normalize();
        //�^�O�ɉ����ă{�[���ɗ͂�^����
        if (other.gameObject.tag == targetTag)
        {
            //���S�n�X�Ń{�[�����~�߂邽�߂ɑ��x������������
            r.velocity *= 0.9f;
            r.AddForce(direction * -20.0f, ForceMode.Acceleration);
        }
        else
        {
            r.AddForce(direction * 80.0f, ForceMode.Acceleration);
        }
    }
}
