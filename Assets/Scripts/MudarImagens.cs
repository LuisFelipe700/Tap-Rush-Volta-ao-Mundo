using UnityEngine;

public class MudarImagens : MonoBehaviour
{
    public SpriteRenderer backgroundRenderer;
    public Sprite[] backgrounds;

    void Start()
    {
        if (backgrounds.Length == 0 || backgroundRenderer == null) return;

        int index = Random.Range(0, backgrounds.Length);
        Sprite spriteEscolhido = backgrounds[index];
        backgroundRenderer.sprite = spriteEscolhido;

        AjustarFundo(spriteEscolhido);
    }

    void AjustarFundo(Sprite sprite)
    {
        Camera cam = Camera.main;
        if (sprite == null || cam == null) return;

        Vector2 tamanhoSprite = sprite.bounds.size;
        float alturaTela = 2f * cam.orthographicSize;
        float larguraTela = alturaTela * cam.aspect;
        float escala = Mathf.Max(larguraTela / tamanhoSprite.x, alturaTela / tamanhoSprite.y);

        backgroundRenderer.transform.localScale = Vector3.one * escala;
        backgroundRenderer.transform.position = cam.transform.position;
    }
}
