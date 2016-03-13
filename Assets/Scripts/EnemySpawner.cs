using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    Transform[] spawnPoints;
    [SerializeField] GameObject enemy;
    [SerializeField]
    float startDelay = 3f;

    [SerializeField]
    float spawnTime = 3f;

    public Text figuraDaVez;

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
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

        TouchRastro.tipoFigura = RandTipoFig(); // Seleciona o tipo de figura que tem que acertar o rabisco
        switch(TouchRastro.tipoFigura)
        {
            case GameManager.TipoFigura.HOR:
                figuraDaVez.text = "Horizontal";
                break;
            case GameManager.TipoFigura.VER:
                figuraDaVez.text = "Vertical";
                break;

        }
        
    }

    public GameManager.TipoFigura RandTipoFig()
    {
        int index = Random.Range(0, 2);
        return tipos[index];
    }
}
