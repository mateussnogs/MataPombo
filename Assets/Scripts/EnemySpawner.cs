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

    public GameObject horizontal;
    public GameObject vertical;

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

        TouchRastro.tipoFigura = RandTipoFig(); // Seleciona o tipo de figura que tem que acertar o rabisco
        switch(TouchRastro.tipoFigura)
        {
            case GameManager.TipoFigura.HOR:
                GameObject hor = Instantiate(horizontal, spawnPoints[spawnPointIndex].position - new Vector3(0, 1.2f, 0), Quaternion.identity) as GameObject;
                hor.transform.SetParent(Enemy.transform);
                break;
            case GameManager.TipoFigura.VER:
                GameObject ver = Instantiate(vertical, spawnPoints[spawnPointIndex].position - new Vector3(0, 1.2f, 0), Quaternion.identity) as GameObject;
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
