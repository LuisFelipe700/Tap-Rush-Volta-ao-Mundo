using UnityEngine;

public class FakeTarget : MonoBehaviour
{
    public AudioClip explosionSound; // ← Aqui você declara a variável

    private void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 2f); // mesma velocidade de queda
    }

    void OnMouseDown()
   
    {
        // Som de explosão
        if (explosionSound != null)
        {
            AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position);
        }

        // Finaliza o jogo
        GameManager gm = FindAnyObjectByType<GameManager>();
        if (gm != null)
        {
            gm.TriggerGameOver();
        }
    }
}
