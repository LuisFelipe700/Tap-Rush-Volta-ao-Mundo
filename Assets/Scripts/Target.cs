using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    public float lifetime = 5f;
    public ParticleSystem hitEffect;
    public AudioClip hitSound;

    void Start()
    {
        transform.localScale = Vector3.zero;
        StartCoroutine(ScaleUp());
        StartCoroutine(DestroyAfterTime());
    }
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 2f); // velocidade de queda

    }

    IEnumerator ScaleUp()
    {
        float duration = 0.7f;
        float time = 0f;
        Vector3 startScale = Vector3.zero;
        Vector3 endScale = Vector3.one;

        while (time < duration)
        {
            transform.localScale = Vector3.Lerp(startScale, endScale, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.localScale = endScale;
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(lifetime);
        //Destroy(gameObject);
    }

    [System.Obsolete]
    void OnMouseDown()
    {
        // Busca o GameManager na cena e adiciona pontuação
        GameManager gm = FindObjectOfType<GameManager>();
        if (gm != null)
        {
            gm.AddScore();
        }

        // Instancia efeito visual
        if (hitEffect != null)
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }

        // Reproduz som
        if (hitSound != null)
        {
            AudioSource.PlayClipAtPoint(hitSound, Camera.main.transform.position);
        }

        Destroy(gameObject);
    }
}
