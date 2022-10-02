using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCircle : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] points;//Масив точок
    public Transform MovePoint;// Позиція точки що рухається
    private List<Vector3>  pointsCurve;// Записуються координати для переміщення MovePoint
    private Vector3 p1,p2,p3;// використовується для лінійної інтерполяції
    private float timeStart;// стартовий час на початку руху MovePoint
    public float duration = 4;
    public float countLine = 12;
    private int groupCurve = 0;
    //Для лінії
    private LineRenderer lineCurve;
    public float animationDuration = 3f;
    void Start()
    {
        pointsCurve = new List<Vector3>();
        lineCurve = GetComponent<LineRenderer>();
        SetPositionCurve();
        createMoveCurve();
    }

    void SetPositionCurve()
    {
        int curveNumber = 0;
        Vector3 p0, p1, p2,p01,p12,p123;
        List<Vector3> CurvsPosition = new List<Vector3>();
        List<Vector3> CurvsLines = new List<Vector3>();
        for (int i = 0; i < 4; i++)//Перебираэмо кожну з 4 кривих
        {
            CurvsPosition.Clear();
            for(int j = 0; j < 4; j++)//Записуэмо 4 головних точок з кривої
            {
                CurvsPosition.Add(points[curveNumber].position);
                curveNumber++;
            }
            for (float k = 0;k<=1; k +=0.1f/countLine)//
            {
                p0 = Vector3.Lerp(CurvsPosition[0], CurvsPosition[1], k);
                p1 = Vector3.Lerp(CurvsPosition[1], CurvsPosition[2], k);
                p2 = Vector3.Lerp(CurvsPosition[2], CurvsPosition[3], k);
                p01 = Vector3.Lerp(p0,p1 , k);
                p12 = Vector3.Lerp(p1, p2, k);
                p123 = Vector3.Lerp(p01, p12, k);
                CurvsLines.Add(p123);// Записуєсо кординати кривої
            }
        }
        lineCurve.positionCount = CurvsLines.Count;
        lineCurve.SetPositions(CurvsLines.ToArray());
        CurvsPosition.Clear();
        CurvsLines.Clear();
    }
    // Update is called once per frame
    void createMoveCurve()
    {
        
        for (int i = 0; i<4;i++)
        {
            
            pointsCurve.Add(points[groupCurve].position);
            groupCurve++;
            
        }
        if(groupCurve == points.Length)
        {

            groupCurve = 0;
            
        }
        timeStart = Time.time;
    }
    void Update()
    {
        Move();
    }
    private void Move()
    {
        float u = (Time.time - timeStart) / duration;
        if (u >= 1)
        {
            pointsCurve.Clear();
            createMoveCurve();
            u = 0;
        }
        p1 = Vector3.Lerp(pointsCurve[0], pointsCurve[1], u);
        p2 = Vector3.Lerp(pointsCurve[1], pointsCurve[2], u);
        p3 = Vector3.Lerp(pointsCurve[2], pointsCurve[3], u);
        Vector3 p12 = Vector3.Lerp(p1, p2, u);
        Vector3 p23 = Vector3.Lerp(p2, p3, u);
        Vector3 p123 = Vector3.Lerp(p12, p23, u);
        p123.z = -1;
        MovePoint.position = p123;
       
    }
}
