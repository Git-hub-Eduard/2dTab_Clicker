using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTapCircles : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] points;
    public GameObject prefabTapClicker;
    public Color[] ColorsCircle;
    private void Start()
    {
        if (PlayerPrefs.GetInt("skinNum") <= 6)
        {
            prefabTapClicker.GetComponent<SpriteRenderer>().color = ColorsCircle[PlayerPrefs.GetInt("skinNum") - 1];
        }
        CreateTapClicker();
        
        
    }

    /// <summary>
    /// Создает новый спрайт
    /// </summary>
    public void CreateTapClicker()
    {
        int number = Random.Range(0, points.Length);
        Vector3 pos;
        float u = Random.Range(0f,1f);
        if(number == 0)
        {
            pos = Vector3.Lerp(points[number].position, points[number + 1].position, u);
        }
        else if(number == points.Length-1)
        {
            pos = Vector3.Lerp(points[number].position, points[0].position, u);
        }
        else
        {
            pos = Vector3.Lerp(points[number].position, points[number-1].position, u);
        }
        pos.z = -1;
        Spawn(prefabTapClicker, pos);
    }
    public void Spawn(GameObject prefab, Vector3 position)
    {
        GameObject thisPrefab = Instantiate(prefab,position,Quaternion.identity);
        thisPrefab.transform.SetParent(this.transform, true);
    }
   
}
