using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    void Update()
    {
        // Agora o jogo só reinicia se apertar ESPAÇO ou ENTER
        // Isso evita que o clique no botão "Sair" reinicie o jogo por engano
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("CenaJogo");
        }
    }

    // Função que o botão de Sair vai chamar
    public void SairDoJogo()
    {
        Debug.Log("O jogador fechou o jogo.");
        Application.Quit(); // Fecha o .exe
    }
}
