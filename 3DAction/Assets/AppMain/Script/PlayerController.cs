using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �U���{�^���N���b�N���ɌĂяo�����R�[���o�b�N
    private Animator m_animator = null;
    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }
    public void OnAttackButtonClicked()
    {
        //Debug.Log("�U���I");
        m_animator.SetTrigger("isAttack");
    }
}