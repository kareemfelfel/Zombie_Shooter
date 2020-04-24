using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescueHandler : MonoBehaviour
{
    [SerializeField] Canvas WinCanvas;
    // Start is called before the first frame update
    void Start()
    {
        WinCanvas.enabled = false;
    }

    // function that pops up the winning canvas
    public void HandleWin()
    {
        WinCanvas.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
