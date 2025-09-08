using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string game;

    public void Jogo()
    {
        SceneManager.LoadScene(game);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
