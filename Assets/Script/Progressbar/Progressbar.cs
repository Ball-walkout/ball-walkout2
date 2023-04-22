using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreationEditor;
using PathCreation;

public class Progressbar : MonoBehaviour
{
    PathCreator creator;
    PathEditor pathEditor;
    BezierPath bezierPath;
    Bounds bounds;
    // Start is called before the first frame update
    void Start()
    {
       // float a = pathEditor.DrawBezierPathSceneEditor.bounds;
        bezierPath = creator.EditorData.bezierPath;
        bounds = bezierPath.CalculateBoundsWithTransform (creator.transform);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(bezierPath.CalculateBoundsWithTransform (creator.transform).size);   
    }
}
