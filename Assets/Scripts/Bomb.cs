using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float speed = 3.5f; // NOVIDADE: Velocidade da bomba
    public AudioClip explosionSound;
    public ParticleSystem explosionEffect;

    void OnMouseDown()
    {
        // Toca o som de explos�o
        if (explosionSound != null)
        {
            AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position);
        }

        // Instancia o efeito de explos�o
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // Finaliza o jogo
        GameManager.Instance.TriggerGameOver();

        Destroy(gameObject);
    }

    void Update()
    {
        // A bomba agora se move com a velocidade da vari�vel 'speed'
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
}