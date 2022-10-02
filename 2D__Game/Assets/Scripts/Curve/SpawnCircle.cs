using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCircle : MonoBehaviour
{
    public Transform[] points;
    public GameObject prefabTapClicker;
    public Color[] ColorsCircle;
    private List<Vector3> curvePoints;
    Vector3 p0, p1, p2;
    // Start is called before the first frame update
    void Start()
    {
        curvePoints = new List<Vector3>();
        if (PlayerPrefs.GetInt("skinNum") <= 6)
        {
            prefabTapClicker.GetComponent<SpriteRenderer>().color = ColorsCircle[PlayerPrefs.GetInt("skinNum") - 1];
        }
        CreateTabCircle();
    }

    public void CreateTabCircle()
    {
        Vector3 pos;
        int group  = Random.Range(0, 4);
        curvePoints.Clear();
        switch (group)
        {
            case 0:
                {
                    for (int i = 0; i < 4; i++)
                    {
                        curvePoints.Add(points[i].position);
                    }
                }
            break;
            case 1:
                {
                    for(int i = 4; i<8;i++)
                    {
                        curvePoints.Add(points[i].position);
                    }
                }
            break;
            case 2:
                {
                    for (int i = 8; i < 12; i++)
                    {
                        curvePoints.Add(points[i].position);
                    }
                }
                break;
            case 3:
                {
                    for (int i = 12; i < 16; i++)
                    {
                        curvePoints.Add(points[i].position);
                    }
                }
                break;
        }
        float u = Random.Range(0.0f, 1.0f);
        p0 = Vector3.Lerp(curvePoints[0], curvePoints[1], u);
        p1 = Vector3.Lerp(curvePoints[1],curvePoints[2], u);
        p2 = Vector3.Lerp(curvePoints[2],curvePoints[3], u);
        Vector3 p01 = Vector3.Lerp(p0, p1, u);
        Vector3 p12 = Vector3.Lerp(p1, p2, u);
        pos = Vector3.Lerp(p01, p12, u);
        pos.z = -1;
        Spawn(prefabTapClicker, pos);
    }
    public void Spawn(GameObject prefab, Vector3 position)
    {
        GameObject thisPrefab = Instantiate(prefab, position, Quaternion.identity);
        thisPrefab.transform.SetParent(this.transform, true);
    }
    // Update is called once per frame
    
}
