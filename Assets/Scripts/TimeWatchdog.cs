using UnityEngine;

using UnityEngine;

public class TimeWatchdog : MonoBehaviour
{
    void Update()
    {
        // Se o jogo n�o estiver pausado, garanta que o tempo corra normalmente
        if (!GameManager.isPaused)
        {
            Time.timeScale = 1f;
        }
    }
}