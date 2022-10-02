using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] points;
    public Transform pointAB;
    private Vector3 p0, p1;
    private LineRenderer line;
    private float speedInterpolate;
    private int i = 0;
    private float timeStart;
    public float duration=4;
    [Header("Поменять направление движения")]
    public bool EndStartMove;
    private Main main;
    private void Start()
    {
        main = GameObject.Find("Main Camera").GetComponent<Main>();
        line = GetComponent<LineRenderer>();
        DrawLine();
        Checkpoint();
    }

    // Update is called once per frame
    void Update()
    {
        
        Move();
        
    }
    void DrawLine()
    {
        line.positionCount = points.Length;
        for (int i = 0; i < points.Length; i++)
        {
            line.SetPosition(i, points[i].position);
        }
        line.SetPosition(0, points[0].position);
    }
    void Checkpoint()
    {
        if(i != points.Length-1)
        {
            p0 = points[i].position;
            p1 = points[i+1].position;
            i++;
        }
        else
        {
            p0  = points[i].position;
            p1 = points[0].position;
            i = 0;
        }
        
        timeStart = Time.time;
    }

    void BackChackPoint()
    {
        if(i == 0)
        {
            p0 = points[i].position;
            p1 = points[points.Length-1].position;
            i = points.Length-1;
        }
        else
        {
            p0 = points[i].position;
            p1 = points[i - 1].position;
            i--;
        }
        timeStart = Time.time;
    }
    void Move()
    {
        float u = (Time.time - timeStart) / duration;
        if (main.RandomDirection <=0.5f && EndStartMove == true)
        {
            
            if (u >= 1)
            {
                
                BackChackPoint();
                u = 0;
            }
            p0.z = -1;
            p1.z = -1;
            pointAB.position = Vector3.Lerp(p0, p1, u);
        }
        else
        {
            if (u >= 1)
            {
                Checkpoint();
                u = 0;
            }
            p0.z = -1;
            p1.z = -1;
            pointAB.position = Vector3.Lerp(p0, p1, u);
        }
        
            
        
        
    }
}
