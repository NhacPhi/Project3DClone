using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    private RectTransform rectComponent;

    public float rotateSpeed = 100f;
    private bool isRotation;

    //public Canvas canvas;
    private void Start()
    {
        rectComponent = GetComponent<RectTransform>();

        isRotation = false;
    }

    private void Update()
    {
        //if(canvas.enabled == true)
        //{
        //    isRotation = true;
        //}else
        //{
        //    isRotation = false;
        //    rectComponent.eulerAngles = new Vector3(0,0,270);
        //}


        if (isRotation)
        {
            //Debug.Log("R = "+ rectComponent.eulerAngles.z);
            //Start 270
            // 162-130
            if (rectComponent.eulerAngles.z > 97)
                rectComponent.Rotate(0f, 0f, -rotateSpeed * Time.deltaTime);
            else
                isRotation = false;
        }

    }

}