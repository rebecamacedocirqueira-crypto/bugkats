using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script defines the borders of ‘Player’s’ movement and handles WASD/Arrow keys input.
/// </summary>

[System.Serializable]
public class Borders
{
    [Tooltip("offset from viewport borders for player's movement")]
    public float minXOffset = 1.5f, maxXOffset = 1.5f, minYOffset = 1.5f, maxYOffset = 1.5f;
    [HideInInspector] public float minX, maxX, minY, maxY;
}

public class PlayerMoving : MonoBehaviour {

    [Tooltip("offset from viewport borders for player's movement")]
    public Borders borders;
    Camera mainCamera;
    bool controlIsActive = true; 

    [Header("Configurações de Movimento")]
    [Tooltip("Velocidade de movimento do gatinho pelo teclado")]
    public float velocidade = 15f; 

    public static PlayerMoving instance; //unique instance of the script for easy access to the script

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        mainCamera = Camera.main;
        ResizeBorders();                //setting 'Player's' moving borders deending on Viewport's size
    }

    private void Update()
    {
        if (controlIsActive)
        {
            // 1. CAPTURA AS TECLAS (W,A,S,D E SETAS AO MESMO TEMPO)
            float movimentoHorizontal = Input.GetAxisRaw("Horizontal");
            float movimientoVertical = Input.GetAxisRaw("Vertical");

            // 2. CRIA O VETOR DE DIREÇÃO
            Vector3 direcao = new Vector3(movimentoHorizontal, movimientoVertical, 0);

            // 3. MOVE O PERSONAGEM COM BASE NA VELOCIDADE
            transform.Translate(direcao * velocidade * Time.deltaTime);

            // 4. LIMITA O GATINHO DENTRO DOS BORDAS DA TELA (Mantendo o sistema original que veio no seu projeto)
            transform.position = new Vector3    
                (
                Mathf.Clamp(transform.position.x, borders.minX, borders.maxX),
                Mathf.Clamp(transform.position.y, borders.minY, borders.maxY),
                0
                );
        }
    }

    //setting 'Player's' movement borders according to Viewport size and defined offset
    void ResizeBorders() 
    {
        borders.minX = mainCamera.ViewportToWorldPoint(Vector2.zero).x + borders.minXOffset;
        borders.minY = mainCamera.ViewportToWorldPoint(Vector2.zero).y + borders.minYOffset;
        borders.maxX = mainCamera.ViewportToWorldPoint(Vector2.right).x - borders.maxXOffset;
        borders.maxY = mainCamera.ViewportToWorldPoint(Vector2.up).y - borders.maxYOffset;
    }
}