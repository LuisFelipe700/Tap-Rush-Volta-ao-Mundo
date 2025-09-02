using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void Jogo()
    {

        SceneManager.LoadScene("Game");
    }
    public void cr()
    {
        SceneManager.LoadScene("Creditos");
    }
    public void Pause()
    {
        SceneManager.LoadScene("Pause");
    }
    public void menu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    } 







}