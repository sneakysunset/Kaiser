using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviorSupplement : MonoBehaviour
{
    [SerializeField] public bool rotate;
    [SerializeField] public float rotateSpeed;
    [SerializeField] public bool lookAtTarget;
    [SerializeField] public float lookAtDelay;
    [SerializeField] public Transform Target;
    Vector3 targetPos;


    private void Start()
    {
        if (lookAtDelay > 0)
            StartCoroutine(lookAtDelayer(lookAtDelay));
    }

    void Update()
    {
         targetPos = new Vector3(Target.position.x, transform.position.y, Target.position.z);

        if (rotate)
            transform.Rotate(0, Time.deltaTime * rotateSpeed, 0);

        if (lookAtTarget && lookAtDelay == 0)
            transform.LookAt(targetPos);
    }

    IEnumerator lookAtDelayer(float timer)
    {
        yield return new WaitForSeconds(timer);
        if(lookAtTarget)
            transform.LookAt(targetPos);

        StartCoroutine(lookAtDelayer(lookAtDelay));
    }
}
