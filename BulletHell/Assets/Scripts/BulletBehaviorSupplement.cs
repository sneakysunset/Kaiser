using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletFury;
using BulletFury.Data;


public class BulletBehaviorSupplement : MonoBehaviour
{
    [SerializeField] public bool rotate;
    [SerializeField] public float rotateSpeed;
    [SerializeField] public bool lookAtTarget;
    [SerializeField] public float lookAtDelay;
    [SerializeField] public Transform Target;
    Vector3 targetPos;
    public BulletManager BombBullets;

    private void Start()
    {
        if (lookAtDelay > 0)
            StartCoroutine(lookAtDelayer(lookAtDelay));
    }

    void Update()
    {
        if(Target!=null)
            targetPos = new Vector3(Target.position.x, transform.position.y, Target.position.z);

        if (rotate)
            transform.Rotate(0, Time.deltaTime * rotateSpeed, 0);

        if(Target != null)
            if (lookAtTarget && lookAtDelay == 0)
                transform.LookAt(Target.position);
    }

    IEnumerator lookAtDelayer(float timer)
    {
        yield return new WaitForSeconds(timer);
        if (Target != null)
            if (lookAtTarget)
                transform.LookAt(targetPos);

        StartCoroutine(lookAtDelayer(lookAtDelay));
    }

    public void BombEffect(int a, BulletContainer bulletContainer, bool isDeadFromTime)
    {
        if (isDeadFromTime)
        {
            BombBullets.Spawn(bulletContainer.Position, forward: BombBullets.Plane == BulletFury.Data.BulletPlane.XY ? transform.up : transform.forward);
        }
    }
}
