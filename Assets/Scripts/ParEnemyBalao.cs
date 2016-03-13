using UnityEngine;
using System.Collections;

public class ParEnemyBalao  {

    public GameObject enemy;
    public GameManager.TipoFigura tipoFig;

	public ParEnemyBalao(GameObject enemy, GameManager.TipoFigura tipoFig)
    {
        this.enemy = enemy;
        this.tipoFig = tipoFig;
    }
}
