using UnityEngine;

using UnityEngine;

public class TimeWatchdog : MonoBehaviour
{
    void Update()
    {
        // Se o jogo não estiver pausado, garanta que o tempo corra normalmente
        if (!GameManager.isPaused)
        {
            Time.timeScale = 1f;
        }
    }
}