using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //�d�͉����x
    const float Gravity = 9.81f;
    //�d�͂̓K�p�
    public float gravityScale = 1.0f;
    // Update is called once per frame
    void Update()
    {
        Vector3 vector = new Vector3();
        if (Application.isMobilePlatform)
        {
            vector.x = Input.acceleration.x;
            vector.z = Input.acceleration.y;
            vector.y = Input.acceleration.z;
        }
        else
        {
            //�L�[�̓��͂����m���x�N�g����ݒ�
            vector.x = Input.GetAxis("Horizontal");
            vector.z = Input.GetAxis("Vertical");
            //���������̔���̓L�[��z�Ƃ���
            if (Input.GetKey("z"))
            {
                vector.y = 1.0f;
            }
            else
            {
                vector.y = -1.0f;
            }
        }
        //�V�[���̏d�͂���̓x�N�g���̕����ɍ��킹�ĕω�������
        Physics.gravity = Gravity * vector.normalized * gravityScale;
    }
}
