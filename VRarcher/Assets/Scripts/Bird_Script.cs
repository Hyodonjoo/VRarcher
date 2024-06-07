using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Script : MonoBehaviour
{

    // ���ο� ��ǥ ��ġ�� �����ϴ� ����
    public float changeTargetInterval = 5f; 
    public float moveSpeed = 1f; //�̵��ӵ�
    public float rotationSpeed = 30f; // ȸ���ӵ�
    public float minZ = 10f;
    public float maxZ = 20f;
    public float maxMoveDistance = 60f; //�󸶳� �ٲ������

    private Vector3 targetPosition; // ��ǥ ��ġ
    private float timer;
    // ���� ���
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
        // Ÿ�̸� ������Ʈ
        timer -= Time.deltaTime;

        // Ÿ�̸Ӱ� 0 ���ϰ� �Ǹ� ���ο� ��ǥ ��ġ ����
        if (timer <= 0f)
        {
            //Debug.Log("�ð���");
            SetNewTargetPosition();
            timer = changeTargetInterval;
        }


        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // �̵� ������ ���ϵ��� ȸ��
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
      

        // ���ο� ��ǥ ��ġ ����
        targetPosition = new Vector3(newX, newY, newZ);
        
       // Debug.Log($"New target position: {targetPosition}");
    }


}
