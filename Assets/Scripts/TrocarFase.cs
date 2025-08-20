using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarFase : MonoBehaviour
{
    // Este método pode ser chamado por qualquer botão
    public void ChangeToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
