using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class NejikoController : MonoBehaviour
{
    const int MinLane = -2;
    const int MaxLane = 2;
    const float LaneWidth = 1.0f;
    // Start is called before the first frame update
    CharacterController controller;
    Animator animator;
    Vector3 moveDirection = Vector3.zero;
    int targetLane;

    public float gravity;
    public float speedZ;
    public float speedX;
    public float speedJump;
    public float accelerationZ;
    void Start()
    {
        //�K�v�ȃR���|�[�l���g�������擾
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        //�f�o�b�O�p
        if (Input.GetKeyDown("left")) MoveToLeft();
        if (Input.GetKeyDown("right")) MoveToRight();
        if (Input.GetKeyDown("space")) Jump();
        //���X�ɉ�����Z�����ɏ�ɑO�i����
        float acceleratedZ = moveDirection.z + (accelerationZ * Time.deltaTime);
        moveDirection.z = Mathf.Clamp(accelerationZ,0,speedZ);
        //X�����͖ڕW�̃|�W�V�����܂ł̍����̊����ő��x���v�Z
        float ratioX = (targetLane * LaneWidth - transform.position.x) / LaneWidth;
        moveDirection.x = ratioX * speedX;
        /*if (controller.isGrounded)
        {
            if (Input.GetAxis("Vertical") > 0.0f)
            {
                moveDirection.z = Input.GetAxis("Vertical") * speedZ;
            }
            else
            {
                moveDirection.z = 0;
            }
            transform.Rotate(0, Input.GetAxis("Horizontal") * 3,0);
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = speedJump;
                animator.SetTrigger("Jump");
            }
        }*/
        //�d�͕��̗͂𖈃t���[���ʒm
        moveDirection.y -= gravity * Time.deltaTime;
        //�ړ����s
        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        controller.Move(globalDirection * Time. deltaTime);
        //�ړ���ڒn���Ă���Y�����̑��x�̓��Z�b�g����
        if (controller.isGrounded) moveDirection.y = 0;
        //���x��0�ȏ�Ȃ瑖���Ă���t���O��true�ɂ���
        animator.SetBool("run", moveDirection.z > 0.0f);
    }
    //���̃��[���Ɉړ����J�n
    public void MoveToLeft()
    {
        if (controller.isGrounded && targetLane > MinLane) targetLane--;
    }
    //�E�̃��[���Ɉړ����J�n
    public void MoveToRight()
    {
        if (controller.isGrounded && targetLane < MaxLane) targetLane++;
    }
    public void Jump()
    {
        if (controller.isGrounded)
        {
            moveDirection.y = speedJump;
            //�W�����v�g���K�[��ݒ�
            animator.SetTrigger("jump");
        }
    }
}
