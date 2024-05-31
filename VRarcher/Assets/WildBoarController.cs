using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildBoarController : MonoBehaviour
{
    public GameObject player; // 플레이어의 GameObject
    public float speed = 3f; // Wild Boar의 이동 속도
    public float attackDistance = 2.5f; // 공격 거리
    private Animator animator; // 애니메이터 컴포넌트

    void Start()
    {
        // Animator 컴포넌트 가져오기
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        Debug.Log("거리 = " + distanceToPlayer); 

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
        // 이동 애니메이션 실행
        animator.SetBool("isRunning", true);

        // 플레이어를 향해 회전
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f); // 회전 속도는 더 빠르게 설정

        // 앞으로 이동
        transform.position += direction * speed * Time.deltaTime;
        //Debug.Log("x : " + transform.position.x + " y : " + transform.position.y + " z : " + transform.position.z);
    }

    void StopMoving()
    {
        // 이동 애니메이션 중지
        animator.SetBool("isRunning", false);
        animator.SetBool("isAttacking", true);
        //Debug.Log("맷돼지가 멈춤");
    }


}
