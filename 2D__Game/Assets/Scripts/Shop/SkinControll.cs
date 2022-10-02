using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkinControll : MonoBehaviour
{
    // Start is called before the first frame update
    public int skinNum;// ����� ��������� ����
    public Text buyBotton;// ����� ������
    public GameObject IconEquip; // ��������, �� ������ �� ��� �������
    public int price; // ֳ�� ����

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
        if(PlayerPrefs.GetInt(GetComponent<Image>().name + "buy")==0)// ���� �� ��������
        {
            buyBotton.text = price.ToString();
            IconEquip.SetActive(false);
        }
        else if(PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 1)//���� ��������
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
        if(PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 0)// ���� �� ��������
        {
            if(Main.points >= price)
            {
                buyBotton.text = "equipped";
                IconEquip.SetActive(true);
                Fon.GetComponent<Image>().sprite = Skin; //������ ���
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
        else if(PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 1)//���� ��������
        {
            buyBotton.text = "equipped";
            IconEquip.SetActive(true);
            Fon.GetComponent<Image>().sprite = Skin; //������ ���
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
