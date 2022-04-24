using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadonBehavior : MonoBehaviour

{
    public Transform Target;
    public bool lookAt;
    public float timer;

    private void OnEnable()
    {
        StartCoroutine(StopFocus(timer));
    }

    void Update()
    {
        if (lookAt)
        {
            transform.LookAt(new Vector3(Target.position.x, transform.position.y, Target.position.z));
            transform.Rotate(0, 180, 0);
        }
    }

    IEnumerator StopFocus(float timer)
    {
        yield return new WaitForSeconds(timer);
        lookAt = false;
    }

}
