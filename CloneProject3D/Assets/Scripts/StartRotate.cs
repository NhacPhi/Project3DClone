using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRotate : MonoBehaviour
{
    public bool IsRotate = false;

    public float speedRotate = 90;
    // Start is called before the first frame update
    void Start()
    {
        IsRotate = false;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(IsRotate)
        {
            transform.Rotate(0,speedRotate * Time.deltaTime, 0);
        }
    }
    public void ActiveRoate(bool value)
    {
            gameObject.SetActive(value);
            IsRotate = value;
    }
}
