using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingMotion : MonoBehaviour
{
    Animator animator;

    public float Damp;
    public float Speed;
    bool isRunning;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        float speed = v * v + h * h;

        animator.SetFloat("MySpeed", speed);
        Vector3 direction = Vector3.forward * v + Vector3.right * h;
        transform.Translate(direction * Speed * Time.deltaTime,Space.Self);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Damp * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isRunning = !isRunning;
            animator.SetBool("IsRuning", isRunning);
        }
    }
}
