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
    












}