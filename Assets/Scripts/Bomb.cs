using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float speed = 3.5f;
    public AudioClip explosionSound;
    public ParticleSystem explosionEffect;

    void OnMouseDown()
    {

        if (explosionSound != null)
        {
            AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position);
        }


        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }


        GameManager.Instance.TriggerGameOver();

        Destroy(this);
    }

    void Update()
    {

        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
}