using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class TouchRastro : MonoBehaviour {
    public TrailRenderer tr;
    public List<Vector2> positions;
    public Text debugText;
    public Text pontoMin;
    public Text pontoMax;
    public static GameManager.TipoFigura tipoFigura = GameManager.TipoFigura.HOR;
	// Use this for initialization
	void Start () {
	}

    private float speed = 0.03F;
    void Update()
    {
        Touch touch = Input.GetTouch(0);
        if (Input.touchCount > 0 && touch.phase == TouchPhase.Began)
        {
            Vector3 touchPosition = touch.position;
            touchPosition.z = 5;
            transform.position = Camera.main.ScreenToWorldPoint(touchPosition);
            positions = new List<Vector2>();
        }
        else if (Input.touchCount > 0 && touch.phase == TouchPhase.Moved)
        {
            Vector3 touchPosition = touch.position;
            touchPosition.z = 5;
            positions.Add(new Vector2(touchPosition.x, touchPosition.y));

            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = touch.deltaPosition;


            // Move object across XY plane
            transform.Translate(touchDeltaPosition.x * speed, touchDeltaPosition.y * speed, 0);
        }

        //Quando solta o dedo testa se o rabisco foi a figura esperada!
        else if(Input.touchCount > 0 && touch.phase == TouchPhase.Ended)
        {
            if (CheckRabisco(tipoFigura, positions))
            {
                debugText.text = "Acertou!" + "Era: " + tipoFigura.ToString();              
                
            }
            else
            {
                debugText.text = "Errou!";
            }
                
        }
    }

    private bool CheckRabisco(GameManager.TipoFigura tipoFig, List<Vector2> positions)
    {
        bool acertou = false;
        switch (tipoFig)
        {
            case GameManager.TipoFigura.HOR:
                acertou = Ehorizontal(positions);
                break;
            case GameManager.TipoFigura.VER:
                acertou = EVertical(positions);
                break;
        }

        return acertou;
    }

    private bool Ehorizontal(List<Vector2> positions)
    {
        float min = positions[0].y;
        float max = positions[positions.Count - 1].y ;
        pontoMin.text = "Min: " + min.ToString();
        pontoMax.text = "Max: " + max.ToString();
        if (Mathf.Abs(max - min) <= 80)
            return true;
        return false;
    }

    private bool EVertical(List<Vector2> positions)
    {
        float min = positions[0].x;
        float max = positions[positions.Count - 1].x;
        pontoMin.text = "Min: " + min.ToString();
        pontoMax.text = "Max: " + max.ToString();
        if (Mathf.Abs(max - min) <= 60)
            return true;
        return false;
    }
}
