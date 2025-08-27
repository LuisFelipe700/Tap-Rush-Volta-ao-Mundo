using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip trilhaNormal;
    public AudioClip trilhaFrenetica;

    private bool frenesiAtivo = false;

    void Start()
    {
        audioSource.clip = trilhaNormal;
        audioSource.loop = true;
        audioSource.Play();
    }

    void Update()
    {
        int score = GameManager.Instance.score;

        if (score >= 30 && !frenesiAtivo)
        {
            TrocarParaFrenetica();
        }
        else if (score < 30 && frenesiAtivo)
        {
            TrocarParaNormal();
        }
    }

    void TrocarParaFrenetica()
    {
        frenesiAtivo = true;
        audioSource.clip = trilhaFrenetica;
        audioSource.Play();
    }

    void TrocarParaNormal()
    {
        frenesiAtivo = false;
        audioSource.clip = trilhaNormal;
        audioSource.Play();
    }
}
