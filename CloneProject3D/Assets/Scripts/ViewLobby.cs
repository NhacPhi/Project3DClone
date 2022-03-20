using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewLobby : MonoBehaviour
{
    Vector3 baseScale = new Vector3(0.7f, 0.7f, 0.7f);
    bool isPhone = false, isFirst = true;
    float zRot = 0, yRot = 0;
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        isFirst = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (isFirst)
            {
                isFirst = false;
                startPos = Input.mousePosition;
                return;
            }
            else
            {
                //zRot += (Input.mousePosition.y - startPos.y) * 0.1f;
                //zRot = Mathf.Clamp(zRot, -55, 55);
                yRot += (Input.mousePosition.x - startPos.x) * 0.3f;
                yRot = Mathf.Clamp(yRot, -180, 180);
                startPos = Input.mousePosition;
            }
            //ScaleUp();
        }
        else
        {
            isFirst = true;
            zRot = Mathf.Lerp(zRot, 0, 0.2f);
            yRot = Mathf.Lerp(yRot, 0, 0.2f);
            //ScaleDown();
        }
        transform.eulerAngles = new Vector3(0, 180 + yRot, zRot);
    }
    void ScaleUp()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, 0.075f);
    }
    void ScaleDown()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, baseScale, 0.075f);
    }
}
