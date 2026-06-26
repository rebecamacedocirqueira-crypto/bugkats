using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// 1. ADICIONE ESSA LINHA PARA PODER MUDAR DE CENA
using UnityEngine.SceneManagement; 

/// <summary>
/// This script defines which sprite the 'Player" uses and its health.
/// </summary>

public class Player : MonoBehaviour
{
    public GameObject destructionFX;

    public static Player instance; 

    private void Awake()
    {
        if (instance == null) 
            instance = this;
    }

    //method for damage proceccing by 'Player'
    public void GetDamage(int damage)   
    {
        Destruction();
    }    

    //'Player's' destruction procedure
    void Destruction()
    {
        // Gera o efeito visual de destruição normalmente
        Instantiate(destructionFX, transform.position, Quaternion.identity); 
        
        // 2. EM VEZ DE DELETAR O OBJETO, APENAS DESATIVE-O
        // Isso faz o gatinho sumir da tela, mas mantém o script vivo para carregar a próxima fase!
        gameObject.SetActive(false);

        // 3. SEGUNDOS DE ESPERA ANTES DE IR PARA A TELA DE GAME OVER
        // Chama a função "ChamarTelaGameOver" após 1.2 segundos (tempo para ver a explosão)
        Invoke("ChamarTelaGameOver", 1.2f);
    }

    // 4. FUNÇÃO NOVA PARA CARREGAR A SUA TELA LINDA
    void ChamarTelaGameOver()
    {
        // COLOQUE O NOME EXATO DA SUA CENA DE GAME OVER ENTRE AS ASPAS
        SceneManager.LoadScene("GameOver"); 
    }
}















