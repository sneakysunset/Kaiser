using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PathCreator))]
public class PathEditor : Editor
{
    PathCreator creator;
    Path path;


    private void OnSceneGUI()
    {
        Input();
        Draw();
    }

    void Input()
    {
        Event guiEvent = Event.current;
        Vector2 mousePos = HandleUtility.GUIPointToWorldRay(guiEvent.mousePosition).origin;

        if(guiEvent.type == EventType.MouseDown && guiEvent.button == 0 && guiEvent.shift)
        {
            Undo.RecordObject(creator, "Add segment");
            path.AddSegment(/*new Vector3(mousePos.x, creator.transform.position.y, mousePos.y)*/creator.transform.position);
        }
    }

    void Draw()
    {
        for (int i = 0; i < path.NumSegments; i++)
        {
            Vector3[] points = path.GetPointsInSegment(i);
            Handles.color = Color.black;
            Handles.DrawLine(points[1], points[0]);
            Handles.DrawLine(points[2], points[3]);
            Handles.DrawBezier(points[0], points[3], points[1], points[2], Color.green, null, 2);
        }

        Handles.color = Color.red;
        for (int i = 0; i < path.NumPoints; i++)
        {
           Vector3 newPos = Handles.FreeMoveHandle(new Vector3(path[i].x,creator.transform.position.y,path[i].z), Quaternion.identity, .1f, Vector3.zero, Handles.CylinderHandleCap);
            if (path[i] != newPos)
            {
                Undo.RecordObject(creator, "MovePoint");
                path.MovePoint(i, newPos);
            }
        }
    }

    private void OnEnable()
    {
        creator = (PathCreator)target;
        if(creator.path == null)
        {
            creator.CreatePath();
        }
        path = creator.path;
    }
}
