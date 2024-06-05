using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildBoarController : MonoBehaviour
{
    public GameObject player; // �÷��̾��� GameObject
    public float speed = 3f; // Wild Boar�� �̵� �ӵ�
    public float attackDistance = 2f; // ���� �Ÿ�
    private Animator animator; // �ִϸ����� ������Ʈ

    void Start()
    {
        // Animator ������Ʈ ��������
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 playerPosition = player.transform.position;
        float distanceToPlayer = Vector3.Distance(transform.position, playerPosition);
        //Debug.Log("�Ÿ� = " + distanceToPlayer); 

        if (distanceToPlayer <= attackDistance)
        {
          
            StopMoving();
      
        }
        else 
        {
            MoveTowardsPlayer(playerPosition);
        }
        
    }

    void MoveTowardsPlayer(Vector3 playerPosition)
    {
        // �̵� �ִϸ��̼� ����
        animator.SetBool("isRunning", true);
        animator.SetBool("isAttacking", false);

        // �÷��̾ ���� ȸ��
        Vector3 direction = (playerPosition - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f); // ȸ�� �ӵ��� �� ������ ����

        // ������ �̵�
        transform.position += direction * speed * Time.deltaTime;
        //Debug.Log("x : " + transform.position.x + " y : " + transform.position.y + " z : " + transform.position.z);
        Debug.Log("x : " + direction.x + " y : " + direction.y + " z : " + direction.z);
    }

    void StopMoving()
    {
        // �̵� �ִϸ��̼� ����
        animator.SetBool("isRunning", false);
        animator.SetBool("isAttacking", true);
        //Debug.Log("�˵����� ����");
    }


}
