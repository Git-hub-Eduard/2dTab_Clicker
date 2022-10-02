using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkinControll : MonoBehaviour
{
    // Start is called before the first frame update
    public int skinNum;// Номер вибраного скіна
    public Text buyBotton;// Текст кнопки
    public GameObject IconEquip; // Картинка, що означає що скін вибрали
    public int price; // Ціна скіна

    public Image[] skins;
    public Sprite Skin;
    public Image Fon;
    void Start()
    {
        
        if(PlayerPrefs.GetInt("Skin1" + "buy")==0)
        {
            foreach(Image image in skins)
            {
                if("Skin1" == image.name)
                {
                    PlayerPrefs.SetInt("Skin1" + "buy", 1);
                }
                else
                {
                    PlayerPrefs.SetInt(GetComponent<Image>().name + "buy", 0);
                }
            }
           
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt(GetComponent<Image>().name + "buy")==0)// коли не куплений
        {
            buyBotton.text = price.ToString();
            IconEquip.SetActive(false);
        }
        else if(PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 1)//коли куплений
        {
            if(PlayerPrefs.GetInt(GetComponent<Image>().name + "equip")==1)
            {
                IconEquip.SetActive(true);
                buyBotton.text = "equipped";
            }
            else if(PlayerPrefs.GetInt(GetComponent<Image>().name + "equip") == 0)
            {
                buyBotton.text = "equip";
                IconEquip.SetActive(false);
            }
        }
    }
    public void Buy()
    {
        if(PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 0)// коли не куплений
        {
            if(Main.points >= price)
            {
                buyBotton.text = "equipped";
                IconEquip.SetActive(true);
                Fon.GetComponent<Image>().sprite = Skin; //Змінити скін
                PlayerPrefs.SetInt(GetComponent<Image>().name + "buy", 1);
                PlayerPrefs.SetInt("skinNum", skinNum);
                foreach (Image image in skins)
                {
                    if(GetComponent<Image>().name == image.name)
                    {
                        PlayerPrefs.SetInt(GetComponent<Image>().name + "equip", 1);
                    }
                    else
                    {
                        PlayerPrefs.SetInt(image.name + "equip", 0);
                    }
                }
            }
        }
        else if(PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 1)//коли куплений
        {
            buyBotton.text = "equipped";
            IconEquip.SetActive(true);
            Fon.GetComponent<Image>().sprite = Skin; //Змінити скін
            PlayerPrefs.SetInt(GetComponent<Image>().name + "equip", 1);
            PlayerPrefs.SetInt("skinNum", skinNum);
            foreach (Image image in skins)
            {
                if (GetComponent<Image>().name == image.name)
                {
                    PlayerPrefs.SetInt(GetComponent<Image>().name + "equip", 1);
                }
                else
                {
                    PlayerPrefs.SetInt(image.name + "equip", 0);
                }
            }
        }
    }
}
