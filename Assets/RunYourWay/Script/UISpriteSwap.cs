using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISpriteSwap : MonoBehaviour
{
    public Sprite MainImage;
    public Sprite SelectionImage;

    public bool Ready;

    Button ButtonUI;
    void Start()
    {
        ButtonUI = gameObject.GetComponent<Button>();
    }

    void Update()
    {
        if (Ready)
        {
            ButtonUI.image.sprite = SelectionImage;
        }
        else
        {
            ButtonUI.image.sprite = MainImage;
        }
    }
}
