using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private Canvas pauseCanvas;
    [SerializeField] private Canvas hudCanvas;

    public void UnpuaseGame()
    {
        pauseCanvas.enabled = false;
        hudCanvas.enabled = true;
        Time.timeScale = 1;
    }
}
