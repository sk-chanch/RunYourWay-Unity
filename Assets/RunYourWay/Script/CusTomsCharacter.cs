using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CusTomsCharacter : MonoBehaviour
{
    // UI
    public GameObject[] MainBar;
    public GameObject[] Bar;
    public GameObject MainBarPlane;
    public GameObject BarPlane;
    public GameObject GenderPlane;

    // Model
    public GameObject ModelGirle;
    public GameObject ModelMan;
    public CharacterRotate ModelRotate;

    // Customs
    public bool Gender;
    public int Het;
    public int Shirt;
    public int Pants;
    public int Bag;
    public int Accesories;
    public int Shoe;

    void Start()
    {
        ModelRotate = gameObject.GetComponent<CharacterRotate>();
    }

    public void CustomUpdate()
    {
        ModelDetails Model;
        if (Gender)
        {
            ModelMan.SetActive(true);
            ModelGirle.SetActive(false);
            ModelMan.transform.position = new Vector3(0,0,0);
            //ModelMan.transform.tag = "Player";
            Model = ModelMan.GetComponent<ModelDetails>();
            Camera CameraMain = Camera.main;
            CameraMain.transform.LookAt(ModelMan.transform.position);
            CameraMain.transform.Rotate(-10.0f, CameraMain.transform.rotation.y, CameraMain.transform.rotation.z, Space.Self);
        }
        else
        {
            ModelMan.SetActive(false);
            ModelGirle.SetActive(true);
            ModelGirle.transform.position = new Vector3(0, 0, 0);
            //ModelGirle.transform.tag = "Player";
            Model = ModelGirle.GetComponent<ModelDetails>();
            Camera CameraMain = Camera.main;
            CameraMain.transform.LookAt(ModelGirle.transform.position);
            CameraMain.transform.Rotate(-10.0f, CameraMain.transform.rotation.y, CameraMain.transform.rotation.z, Space.Self);
        }
        //Camera CameraPos = Camera.main;
        //CameraPos.transform.Rotate(10.0f, CameraPos.transform.rotation.y, CameraPos.transform.rotation.z, Space.Self);
        //ModelDetails Model = ModelMan.GetComponent<ModelDetails>();
        for (int i = 0; i < Model.PartHat.Length; i++)
        {
            if (Het == i)
            {
                Model.PartHat[i].SetActive(true);
            }
            else
            {
                Model.PartHat[i].SetActive(false);
            }
        }

        for (int i = 0; i < Model.PartShirt.Length; i++)
        {
            if (Shirt == i)
            {
                Model.PartShirt[i].SetActive(true);
            }
            else
            {
                Model.PartShirt[i].SetActive(false);
            }
        }

        for (int i = 0; i < Model.PartPants.Length; i++)
        {
            if (Pants == i)
            {
                Model.PartPants[i].SetActive(true);
            }
            else
            {
                Model.PartPants[i].SetActive(false);
            }
        }

        for (int i = 0; i < Model.PartBag.Length; i++)
        {
            if (Bag == i)
            {
                Model.PartBag[i].SetActive(true);
            }
            else
            {
                Model.PartBag[i].SetActive(false);
            }
        }

        for (int i = 0; i < Model.PartAccessories.Length; i++)
        {
            if (Accesories == i)
            {
                Model.PartAccessories[i].SetActive(true);
            }
            else
            {
                Model.PartAccessories[i].SetActive(false);
            }
        }

        for (int i = 0; i < Model.PartShoe.Length; i++)
        {
            if (Shoe == i)
            {
                Model.PartShoe[i].SetActive(true);
            }
            else
            {
                Model.PartShoe[i].SetActive(false);
            }
        }
    }

    public void ChangeBar(int Num)
    {
        for (int i = 0; i < Bar.Length; i++)
        {
            if (i+1 == Num)
            {
                Bar[i].SetActive(true);
                MainBar[i].GetComponent<UISpriteSwap>().Ready = true;
            }
            else
            {
                Bar[i].SetActive(false);
                MainBar[i].GetComponent<UISpriteSwap>().Ready = false;
            }
        }
    }

    public void ChangPart(int Num)
    {
        if (Num / 100 == 0)
        {
            if (Num % 100 == 1)
            {
                Gender = true;
            }
            else
            {
                Gender = false;
            }
            MainBarPlane.SetActive(true);
            BarPlane.SetActive(true);
            GenderPlane.SetActive(false);
        }
        else if(Num / 100 == 1)
        {
            Het = Num % 100;
        }
        else if (Num / 100 == 2)
        {
            Shirt = Num % 100;
        }
        else if (Num / 100 == 3)
        {
            Pants = Num % 100;
        }
        else if (Num / 100 == 4)
        {
            Bag = Num % 100;
        }
        else if (Num / 100 == 5)
        {
            Accesories = Num % 100;
        }
        else if (Num / 100 == 6)
        {
            Shoe = Num % 100;
        }
        CustomUpdate();
    }

}
