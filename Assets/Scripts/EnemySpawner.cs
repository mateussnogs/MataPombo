using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    Transform[] spawnPoints;
    [SerializeField] GameObject enemy;

    public float startDelay = 3f;

    
    public float spawnTime = 3f;

    public GameObject horizontal;
    public GameObject vertical;
    private float offsetBalao = 0.9f;

    



    public GameManager.TipoFigura[] tipos = { GameManager.TipoFigura.HOR, GameManager.TipoFigura.VER };
    // Use this for initialization
    void Start ()
    {
       InvokeRepeating("Spawn", startDelay, spawnTime);
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void Spawn()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        GameObject Enemy = Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as GameObject;

        //TouchRastro.tipoFigura = RandTipoFig(); 
        GameManager.TipoFigura tipoFig = RandTipoFig(); // Seleciona o tipo de figura que tem que acertar o rabisco
        GameManager.filaInimigos.Add(new ParEnemyBalao(Enemy, tipoFig));

        switch(tipoFig)
        {
            case GameManager.TipoFigura.HOR:
                GameObject hor = Instantiate(horizontal, spawnPoints[spawnPointIndex].position - new Vector3(0, offsetBalao, 0), Quaternion.identity) as GameObject;
                hor.transform.SetParent(Enemy.transform);
                break;
            case GameManager.TipoFigura.VER:
                GameObject ver = Instantiate(vertical, spawnPoints[spawnPointIndex].position - new Vector3(0, offsetBalao, 0), Quaternion.identity) as GameObject;
                ver.transform.SetParent(Enemy.transform);
                break;

        }
        
    }

    private GameManager.TipoFigura RandTipoFig()
    {
        int index = Random.Range(0, 2);
        return tipos[index];
    }
}
