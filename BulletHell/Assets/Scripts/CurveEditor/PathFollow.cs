using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour
{
    public PathCreator pathCrea;
     public Vector3[] pathPoints;
    [Range(0,1)] public float speed;
    public float incr;
    public int pointIndex;
    private void Start()
    {
        pointIndex = 0;
        pathPoints = new Vector3[pathCrea.path.NumPoints];
        for (int i = 0; i < pathPoints.Length; i++)
        {
            pathPoints[i] = pathCrea.path[i];
        }
       // pathPoints = pathCrea.path.poin
    }

    public void Update()
    {
        if(pointIndex < pathPoints.Length-3 && incr<=1)
            incr += (Time.deltaTime * speed);

        if(incr >= 1 && pointIndex < pathPoints.Length - 4)
        {
            incr = 0;
            pointIndex += 3;
        }

        transform.position = pathCrea.path.CubicCurve(pathPoints[pointIndex], pathPoints[pointIndex + 1], pathPoints[pointIndex + 2], pathPoints[pointIndex + 3], incr);
    }
}
