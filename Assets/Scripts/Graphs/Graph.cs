using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab = default;

    [SerializeField, Range(10,100)]
    int resolution = 10;

    [SerializeField, Range(0, 2)]
    int function = 0;

    Transform[] points;

    private void Awake()
    {
        float step = 2f / resolution;
        var scale = Vector3.one * step;
        var position = Vector3.zero;
        points = new Transform[resolution];

        for(int i = 0; i < points.Length; i++)
        {
            Transform point = Instantiate(pointPrefab);
            position.x = (i + 0.5f) * step - 1f;
            //position.y = Mathf.Pow(position.x, 2);
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
            points[i] = point;
        }
    }

    void Update()
    {
        float time = Time.time;

        for(int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            // position.y = Mathf.Pow(position.x, 3);
            if(function == 0)
            {
                position.y = FunctionLibrary.Wave(position.x, time);
            }
            else if(function == 1)
            {
                position.y = FunctionLibrary.MultiWave(position.x, time);
            }
            else
            {
                position.y = FunctionLibrary.Ripple(position.x, time);  
            }
            point.localPosition = position;
            
        }
    }
}
