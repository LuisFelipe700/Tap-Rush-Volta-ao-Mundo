using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarFase : MonoBehaviour
{
    // Este m�todo pode ser chamado por qualquer bot�o
    public void ChangeToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
