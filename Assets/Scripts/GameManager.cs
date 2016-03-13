using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class GameManager : MonoBehaviour {
    public enum TipoFigura { HOR, VER, V};
    public float tempoEspera, proxFig;
    TipoFigura tipoFig = TipoFigura.HOR;
    public static List<ParEnemyBalao> filaInimigos;
    // Use this for initialization
    void Start () {
        filaInimigos = new List<ParEnemyBalao>();
    }
	
	// Update is called once per frame
	void Update () {        
	}
}
