using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterRotate : MonoBehaviour
{
    private float SceneWidth;
    private Vector3 PressPoint;
    private Quaternion StartRotation;

    void Start()
    {
        SceneWidth = Screen.width;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PressPoint = Input.mousePosition;
            StartRotation = transform.rotation;
        }
        else if (Input.GetMouseButton(0))
        {
            float CurrentDistanceBetweenMousePositions = (Input.mousePosition - PressPoint).x;
            transform.rotation = StartRotation * Quaternion.Euler(Vector3.down * (CurrentDistanceBetweenMousePositions / SceneWidth) * 360);
        }
    }
}
