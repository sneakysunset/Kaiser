using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Path
{
    [SerializeField, HideInInspector]
    List<Vector3> points;
    [HideInInspector] public Vector3[] travelPoints;



    public Vector3 Lerp(Vector3 a, Vector3 b, float t)
    {
        return a + (b - a) * t;
    }

    public Vector3 QuadraticCurve(Vector3 a, Vector3 b, Vector3 c, float t)
    {
        Vector3 ab = Lerp(a, b, t);
        Vector3 bc = Lerp(b, c, t);
        return Lerp(ab, bc, t);
    }

    public Vector3 CubicCurve(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
    {
        Vector3 abc = QuadraticCurve(a, b, c, t);
        Vector3 bcd = QuadraticCurve(b, c, d, t);
        return Lerp(abc, bcd, t);
    }

    public Path(Vector3 centre)
    {
        points = new List<Vector3>
        {
            centre+Vector3.left,
            centre+(Vector3.left + Vector3.forward)*.5f,
            centre+(Vector3.right + Vector3.back)*.5f,
            centre + Vector3.right
        };
    }

    public Vector3 this[int i]
    {
        get
        {
            return points[i];
        }
    }


    public int NumPoints
    {
        get
        {
            return points.Count;
        }
    }


    public int NumSegments
    {
        get
        {
            return (points.Count - 4) / 3 + 1;
        }
    }


    public void AddSegment(Vector3 anchorPos)
    {
        points.Add(points[points.Count - 1] * 2 - points[points.Count - 2]);
        points.Add((points[points.Count - 1] + anchorPos) * .5f);
        points.Add(anchorPos);       
    }

    public Vector3[] GetPointsInSegment(int i)
    {
        return new Vector3[] { points[i * 3], points[i * 3 + 1], points[i * 3 + 2], points[i * 3 + 3] };
    }

    public void MovePoint(int i, Vector3 pos)
    {
        points[i] = pos;
    }
}
