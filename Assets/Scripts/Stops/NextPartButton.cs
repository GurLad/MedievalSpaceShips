using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPartButton : MonoBehaviour
{
    public void Click()
    {
        GameController.Current.LoadNextPart();
    }
}
