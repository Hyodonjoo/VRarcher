using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Script : MonoBehaviour
{

    // 새로운 목표 위치를 설정하는 간격
    public float changeTargetInterval = 5f; 
    public float moveSpeed = 1f; //이동속도
    public float rotationSpeed = 30f; // 회전속도
    public float minZ = 10f;
    public float maxZ = 20f;
    public float maxMoveDistance = 60f; //얼마나 바뀔것인지

    private Vector3 targetPosition; // 목표 위치
    private float timer;
    // 맵의 경계
    public Vector2 mapBoundsX = new Vector2(-30f, 30f);
    public Vector2 mapBoundsY = new Vector2(-30f, 30f);

    // Start is called before the first frame update
    void Start()
    {
        SetNewTargetPosition();
        timer = changeTargetInterval;
    }

    // Update is called once per frame
    void Update()
    {
        // 타이머 업데이트
        timer -= Time.deltaTime;

        // 타이머가 0 이하가 되면 새로운 목표 위치 설정
        if (timer <= 0f)
        {
            //Debug.Log("시간됨");
            SetNewTargetPosition();
            timer = changeTargetInterval;
        }


        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // 이동 방향을 향하도록 회전
        Vector3 direction = targetPosition - transform.position;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }

    void SetNewTargetPosition()
    {
        
        float newX = Random.Range(0, 360);
        float newY = Random.Range(0, 30);
        float newZ = Random.Range(0, 360);
      

        // 새로운 목표 위치 설정
        targetPosition = new Vector3(newX, newY, newZ);
        
       // Debug.Log($"New target position: {targetPosition}");
    }


}
