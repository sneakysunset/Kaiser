using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletFury;
using BulletFury.Data;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class BulletBehaviorSupplement : MonoBehaviour
{
    [SerializeField] public bool rotate;
    [SerializeField, HideInInspector] public float rotateSpeed;
    [SerializeField] public bool lookAtTarget;
    [SerializeField, HideInInspector] public float lookAtDelay;
    [SerializeField, HideInInspector] public Transform Target;
    Vector3 targetPos;
    [SerializeField] public bool bomb;
    [SerializeField, HideInInspector] public BulletManager BombBullets;
    public bool movingSpawner;
    public bool endlessSpawn;
    [SerializeField, HideInInspector] public PathCreator pathCrea;
    [SerializeField, HideInInspector] public float timeBeforeStopSpawning;
    [SerializeField, HideInInspector] [Range(0, 1)] public float speed;
    Vector3[] pathPoints;
    float incr;
    int pointIndex;

    private void OnEnable()
    {
        if (!endlessSpawn)
        {
            StartCoroutine(endSpawn(timeBeforeStopSpawning));
        }
    }

    public void enderSpawn()
    {
       
        StartCoroutine(endSpawn(0));
    }

    private void Start()
    {
        if (lookAtDelay > 0)
            StartCoroutine(lookAtDelayer(lookAtDelay));

        if (movingSpawner)
        {
            pointIndex = 0;
            pathPoints = new Vector3[pathCrea.path.NumPoints];
            for (int i = 0; i < pathPoints.Length; i++)
            {
                pathPoints[i] = pathCrea.path[i];
            }
        }
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

        if (movingSpawner)
            MoveSpawner();
    }


    IEnumerator endSpawn(float timer)
    {
        yield return new WaitForSeconds(timeBeforeStopSpawning);
        if(this.tag != "Explosion")
            GetComponent<BulletInstancier>().spawning = false;
    }


    void MoveSpawner()
    {
        if (pointIndex < pathPoints.Length - 3 && incr <= 1)
            incr += (Time.deltaTime * speed);

        if (incr >= 1 && pointIndex < pathPoints.Length - 4)
        {
            incr = 0;
            pointIndex += 3;
        }

        transform.position = pathCrea.path.CubicCurve(pathPoints[pointIndex], pathPoints[pointIndex + 1], pathPoints[pointIndex + 2], pathPoints[pointIndex + 3], incr);
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



#if UNITY_EDITOR

[CustomEditor(typeof(BulletBehaviorSupplement))/*, ExecuteInEditMode*/]
public class OnGUIEditorHide : Editor
{
    //void On
        
    public override void OnInspectorGUI()
    {
        //serializedObject.Update();
       
        
        base.OnInspectorGUI();
        BulletBehaviorSupplement script = target as BulletBehaviorSupplement;

        if (script.rotate)
        {
            script.rotateSpeed = EditorGUILayout.FloatField("rotateSpeed",script.rotateSpeed);
        }

        if (!script.endlessSpawn)
        {
            script.timeBeforeStopSpawning = EditorGUILayout.FloatField("Timer Before Stop Spawning", script.timeBeforeStopSpawning);
        }

        if (script.lookAtTarget)
        {
            script.lookAtDelay = EditorGUILayout.FloatField("lookAtDelay", script.lookAtDelay);
            script.Target = EditorGUILayout.ObjectField("Target", script.Target, typeof(Transform), true) as Transform;
        }

        if (script.bomb)
        {
            script.BombBullets = EditorGUILayout.ObjectField("BombBullets", script.BombBullets, typeof(BulletManager), true) as BulletManager;
        }

        if (script.movingSpawner)
        {
            script.pathCrea = EditorGUILayout.ObjectField("pathCreator", script.pathCrea, typeof(PathCreator), true) as PathCreator;
            script.speed = EditorGUILayout.FloatField("speed", script.speed);
        }
        EditorUtility.SetDirty(script);
        //serializedObject.ApplyModifiedProperties();
    }

    
}


#endif
