using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
    public enum TipoFigura { HOR, VER, V};
    public float tempoEspera, proxFig;
    TipoFigura tipoFig = TipoFigura.HOR;
    public Text textoFiguraDaVez;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {        
	}
}
