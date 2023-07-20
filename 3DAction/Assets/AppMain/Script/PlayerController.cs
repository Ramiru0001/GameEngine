using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //�U������p�I�u�W�F�N�g
    [SerializeField]
    private GameObject m_attackHit = null;
    [SerializeField]
    private ColliderCallReceiver m_footColliderCall = null;
    [SerializeField]
    private float m_jumpPower = 20f;
    // �U���{�^���N���b�N���ɌĂяo�����R�[���o�b�N
    private Animator m_animator = null;
    private Rigidbody m_rigidbody = null;
    //�U�����t���O
    bool m_isAttack = false;
    bool m_isGround = false;
    private void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody>();
        //�U������p�I�u�W�F�N�g���I�t�ɂ���
        m_attackHit.SetActive(false);
        m_footColliderCall.TriggerStayEvent.AddListener(OnFootTriggerStay);
        m_footColliderCall.TriggerExitEvent.AddListener(OnFootTriggerExit);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            OnAttackButtonClicked();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJumpButtonClicked();
        }
    }
    public void OnJumpButtonClicked()
    {
        if (!m_isGround) return;
        m_rigidbody.AddForce(Vector3.up * m_jumpPower, ForceMode.Impulse);
    }
    public void OnAttackButtonClicked()
    {
        if (m_isAttack) return;
        m_isAttack = true;
        //Debug.Log("�U���I");
        m_animator.SetTrigger("isAttack");
    }
    private void OnFootTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Ground")
        {
            m_isGround = true;
            m_animator.SetBool("isGround", m_isGround);
        }
    }
    private void OnFootTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Ground")
        {
            m_isGround = false;
            m_animator.SetBool("isGround", m_isGround);
        }
    }
    private void Anim_AttackHit()
    {
        m_attackHit.SetActive(true);
    }
    private void Anim_AttackEnd()
    {
        m_attackHit.SetActive(false);
        m_isAttack = false;
    }
}