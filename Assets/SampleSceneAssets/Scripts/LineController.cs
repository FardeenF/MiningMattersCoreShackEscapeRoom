using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lr;
    private Transform[] points;
    private List<Transform> list;

    // Start is called before the first frame update
    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    public void SetUpLine(List<Transform> list)
    {
        lr.positionCount = list.Count;//points.Length;
        this.list = list;
    }

    // Update is called once per frame
    void Update()
    {
        //if (list.Count != 0)
        //{
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        lr.SetPosition(i, list[i].position);
        //    }
        //}
    }
}
