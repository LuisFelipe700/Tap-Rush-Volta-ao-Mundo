using UnityEngine;

public class FakeTarget : MonoBehaviour
{
    public AudioClip explosionSound; // ← Aqui você declara a variável

    [System.Obsolete]
    void OnMouseDown()
    {
        // Som de explosão
        if (explosionSound != null)
        {
            AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position);
        }

        // Finaliza o jogo
        GameManager gm = FindObjectOfType<GameManager>();
        if (gm != null)
        {
            gm.TriggerGameOver();
        }
    }
}
