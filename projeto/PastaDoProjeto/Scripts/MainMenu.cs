using UnityEngine;
using UnityEngine.SceneManagement; // Linha essencial para permitir o controle de cenas

public class MainMenu : MonoBehaviour
{
    public void JogarGame()
    {
        // Substitua pelo nome EXATO da sua cena de jogo entre as aspas
        SceneManager.LoadScene("CenaJogo"); 
    }

    public void SairDoGame()
    {
        Debug.Log("O jogador clicou em Sair!");
        Application.Quit(); // Fecha o jogo (só funciona na versão final buildada)
    }
}