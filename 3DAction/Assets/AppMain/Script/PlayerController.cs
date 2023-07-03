using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 攻撃ボタンクリック時に呼び出されるコールバック
    private Animator m_animator = null;
    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }
    public void OnAttackButtonClicked()
    {
        //Debug.Log("攻撃！");
        m_animator.SetTrigger("isAttack");
    }
}