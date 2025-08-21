using UnityEngine;

public class Background : MonoBehaviour
{
    public SpriteRenderer backgroundRenderer;
    public Sprite[] backgrounds;
    private int currentIndex = 0;

    void Start()
    {
        ChangeBackground(currentIndex);
    }

    public void ChangeBackground(int index)
    {
        if (backgrounds == null || backgrounds.Length == 0 || index >= backgrounds.Length) return;

        backgroundRenderer.sprite = backgrounds[index];
        FitSpriteToScreenPreservingAspect(backgroundRenderer, Camera.main);
    }

    void FitSpriteToScreenPreservingAspect(SpriteRenderer sr, Camera cam)
    {
        if (sr.sprite == null || cam == null) return;

        float screenHeight = 2f * cam.orthographicSize;
        float screenWidth = screenHeight * cam.aspect;

        Vector2 spriteSize = sr.sprite.bounds.size;

        float scaleFactor = Mathf.Max(screenWidth / spriteSize.x, screenHeight / spriteSize.y);

        sr.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1f);
        sr.transform.position = cam.transform.position; // centraliza o fundo
    }

    // Exemplo: trocar fundo com tecla
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentIndex = (currentIndex + 1) % backgrounds.Length;
            ChangeBackground(currentIndex);
        }
    }
}
