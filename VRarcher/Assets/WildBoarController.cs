using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildBoarController : MonoBehaviour
{
    public GameObject player; // �÷��̾��� GameObject
    public float speed = 3f; // Wild Boar�� �̵� �ӵ�
    public float attackDistance = 2.5f; // ���� �Ÿ�
    private Animator animator; // �ִϸ����� ������Ʈ

    void Start()
    {
        // Animator ������Ʈ ��������
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        Debug.Log("�Ÿ� = " + distanceToPlayer); 

        if (distanceToPlayer <= attackDistance)
        {
          
            StopMoving();
      
        }
        else 
        {
            MoveTowardsPlayer();
        }
        
    }

    void MoveTowardsPlayer()
    {
        // �̵� �ִϸ��̼� ����
        animator.SetBool("isRunning", true);

        // �÷��̾ ���� ȸ��
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f); // ȸ�� �ӵ��� �� ������ ����

        // ������ �̵�
        transform.position += direction * speed * Time.deltaTime;
        //Debug.Log("x : " + transform.position.x + " y : " + transform.position.y + " z : " + transform.position.z);
    }

    void StopMoving()
    {
        // �̵� �ִϸ��̼� ����
        animator.SetBool("isRunning", false);
        animator.SetBool("isAttacking", true);
        //Debug.Log("�˵����� ����");
    }


}
