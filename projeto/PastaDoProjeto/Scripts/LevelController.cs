using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Serializable classes
[System.Serializable]
public class EnemyWaves 
{
    [Tooltip("time for wave generation from the moment the game started")]
    public float timeToStart;

    [Tooltip("Enemy wave's prefab")]
    public GameObject wave;
}
#endregion

public class LevelController : MonoBehaviour {

    // Lista original de ondas criada no Unity Inspector
    public EnemyWaves[] enemyWaves; 

    [Tooltip("Tempo entre o surgimento de uma onda infinita e outra")]
    public float tempoEntreOndasInfinitas = 5f;

    public GameObject powerUp;
    public float timeForNewPowerup;
    public GameObject[] planets;
    public float timeBetweenPlanets;
    public float planetsSpeed;
    List<GameObject> planetsList = new List<GameObject>();

    Camera mainCamera;   

    private void Start()
    {
        mainCamera = Camera.main;
        
        // Agora o jogo inicia uma rotina que NUNCA para de criar as ondas da sua lista
        StartCoroutine(GeradorInfinitoDeOndas());
        
        StartCoroutine(PowerupBonusCreation());
        StartCoroutine(PlanetsCreation());
    }
    
    // NOVA ROTINA: Sorteia e cria ondas para sempre
    IEnumerator GeradorInfinitoDeOndas()
    {
        // Se você esqueceu de colocar ondas no Inspector, evita crashar o jogo
        if (enemyWaves.Length == 0)
        {
            Debug.LogError("Por favor, adicione pelo menos uma onda (Wave) no componente LevelController do Unity Inspector!");
            yield break;
        }

        // Primeiro, gera as ondas normais baseadas no tempo configurado nelas (para respeitar o começo do jogo)
        for (int i = 0; i < enemyWaves.Length; i++) 
        {
            StartCoroutine(CreateEnemyWave(enemyWaves[i].timeToStart, enemyWaves[i].wave));
        }

        // Descobre qual a onda que demora mais para começar para o modo infinito assumir logo depois dela
        float maiorTempo = 0;
        foreach(var wave in enemyWaves) // CORRIGIDO: de 'em' para 'in'
        {
            if (wave.timeToStart > maiorTempo) maiorTempo = wave.timeToStart;
        }

        // Espera as primeiras ondas programadas acabarem
        yield return new WaitForSeconds(maiorTempo + tempoEntreOndasInfinitas);

        // LOOP INFINITO: Escolhe uma onda aleatória da sua lista e joga na tela de tempos em tempos
        while (true)
        {
            if (Player.instance != null)
            {
                // Escolhe um index aleatório entre as ondas que você cadastrou
                int indiceAleatorio = Random.Range(0, enemyWaves.Length);
                if (enemyWaves[indiceAleatorio].wave != null)
                {
                    Instantiate(enemyWaves[indiceAleatorio].wave);
                }
            }

            // Espera o tempo determinado antes de mandar o próximo grupo de meteoros
            yield return new WaitForSeconds(tempoEntreOndasInfinitas);
        }
    }

    // Mantido para compatibilidade, cria a onda inicial atrasada
    IEnumerator CreateEnemyWave(float delay, GameObject Wave) 
    {
        if (delay != 0)
            yield return new WaitForSeconds(delay);
        if (Player.instance != null && Wave != null)
            Instantiate(Wave);
    }

    // Gerador infinito de Power-ups (Mantido original)
    IEnumerator PowerupBonusCreation() 
    {
        while (true) 
        {
            yield return new WaitForSeconds(timeForNewPowerup);
            if (PlayerMoving.instance != null && powerUp != null)
            {
                Instantiate(
                    powerUp,
                    new Vector2(
                        Random.Range(PlayerMoving.instance.borders.minX, PlayerMoving.instance.borders.maxX), 
                        mainCamera.ViewportToWorldPoint(Vector2.up).y + powerUp.GetComponent<Renderer>().bounds.size.y / 2), 
                    Quaternion.identity
                );
            }
        }
    }

    // Gerador infinito de Planetas de Fundo (Mantido original)
    IEnumerator PlanetsCreation()
    {
        for (int i = 0; i < planets.Length; i++)
        {
            planetsList.Add(planets[i]);
        }
        yield return new WaitForSeconds(10);
        while (true)
        {
            if (planetsList.Count > 0)
            {
                int randomIndex = Random.Range(0, planetsList.Count);
                if (planetsList[randomIndex] != null)
                {
                    GameObject newPlanet = Instantiate(planetsList[randomIndex]);
                    planetsList.RemoveAt(randomIndex);
                    
                    if (planetsList.Count == 0)
                    {
                        for (int i = 0; i < planets.Length; i++)
                        {
                            planetsList.Add(planets[i]);
                        }
                    }
                    if (newPlanet.GetComponent<DirectMoving>() != null)
                    {
                        newPlanet.GetComponent<DirectMoving>().speed = planetsSpeed;
                    }
                }
            }

            yield return new WaitForSeconds(timeBetweenPlanets);
        }
    }
}