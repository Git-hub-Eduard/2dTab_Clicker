using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Анимации")]
    public Animator animator;
    public Animator MainMenu;
    public Animator PointText;
    [Header("Текст интерфейса")]
    public Text pointText;
    public Text MainButtonText;
    public Text MoneyText;
    public GameObject[] figures;
    private GameObject thisFigure;
    public GameObject GameOverMenu;
    private int numberLevel = 0;
    public static int points = 0;
    private int thisFigurePoints = 0;
    public float RandomDirection;
    [Header("Управление")]
    public bool IsTouch;
    [Header("Скины")]
    public Sprite[] Skins;
    public Image Fon;
    void Start()
    {
        Fon.GetComponent<Image>().sprite = Skins[PlayerPrefs.GetInt("skinNum") - 1];
        pointText.text = "0";
        MainButtonText.text = "Level " + (numberLevel + 1);
        //SpawnFigure(numberLevel);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnFigure()
    {
        thisFigure = Instantiate(figures[numberLevel]);
        MainMenu.SetBool("IsClick", true);
        PointText.SetBool("IsPlay", true);
    }
    public void GetPoint()
    {
        points++;
        thisFigurePoints++;
        pointText.text = points.ToString();
        MoneyText.text = "Money: " + Main.points;
        RandomDirection = Random.Range(0, 1f);
        if(thisFigurePoints >= 10)
        {
            numberLevel++;
            thisFigurePoints = 0;
            Destroy(thisFigure);
            if(numberLevel>= figures.Length)
            {
                numberLevel = 0;
            }
            MainButtonText.text = "Level " + (numberLevel + 1);
            PointText.SetBool("IsPlay", false);
            MainMenu.SetBool("IsClick", false);
        }
    }
    public void SetGameOver()
    {
        GameOverMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Restart()
    {
        Destroy(thisFigure);
        GameOverMenu.SetActive(false);
        Time.timeScale = 1f;
        MainMenu.SetBool("IsClick", false);
        PointText.SetBool("IsPlay", false);
    }
    public IEnumerator playAnimation()
    {
        animator.SetBool("IsClick", true);
        yield return new WaitForSeconds(0.75f);
        animator.SetBool("IsClick", false);
    }
}
