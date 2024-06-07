using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniController: MonoBehaviour
{
    public Animator anim;
    private Rigidbody rb;
    private float speed=3;
    private Vector3 direction;
    private bool isRunning;
    private float timeSinceLastUpdate;
    private Quaternion targetRotation;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        SetRandomAnimation();
        timeSinceLastUpdate = 0f;
        targetRotation = transform.rotation;
        
    }

    void Update()
    {

   
        timeSinceLastUpdate += Time.deltaTime;

        
        if (timeSinceLastUpdate >=1f)
        {
            UpdateAnimalBehavior();
            timeSinceLastUpdate = 0f;
        }

      

        // 부드럽게 회전
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 0.5f);

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("walk") || anim.GetCurrentAnimatorStateInfo(0).IsName("run"))
        {
            MoveForward();
        }

     

    }

    //앞으로 전진
    void MoveForward()
    {
        Vector3 forwardMovement = transform.forward * speed * Time.deltaTime;
        rb.MovePosition(rb.position + forwardMovement);
    }

    void UpdateAnimalBehavior()
    {
     
            if (Random.Range(0, 100) < 50)
            {
                float randomYRotation = Random.Range(0, 360);
                targetRotation = Quaternion.Euler(0, randomYRotation, 0);
            }
        
        else
        {
            // 90% 확률로 애니메이션 전환
            if (Random.Range(0, 100) < 90)
            {
                SetRandomAnimation();
            }
        }
    }

    void SetRandomAnimation()
    {
        isRunning = Random.Range(0, 2) == 0;
        anim.SetBool("isRun", isRunning);


        if (isRunning)
        {
            anim.SetBool("isWalk", false);
            speed = 3f;

        }
        else
        {
            anim.SetBool("isWalk", true);
            speed = 1f;
        }
    }

    void FixedUpdate()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

     
    }


}
