using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCanvas : MonoBehaviour
{
    public Canvas UIPlayer;

    public Canvas CanvasTrap;
    // Start is called before the first frame update

    public void SetActiveCanvas(bool value)
    {
        UIPlayer.enabled = value;
    }
    public void SetActiveCavasTrap(bool value)
    {
        CanvasTrap.enabled = value;
    }
}
