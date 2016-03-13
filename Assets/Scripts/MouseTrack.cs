using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MouseTrack : MonoBehaviour
{
    public TrailRenderer tr;
    public List<Vector2> positions;
    public Text debugText;
    public Text pontoMin;
    public Text pontoMax;
    public static GameManager.TipoFigura tipoFigura = GameManager.TipoFigura.HOR;
    private float speed = 0.03F;
    Vector3 mousePosition;

    // Use this for initialization
    void Start ()
    {
	
	}

    void Update()
    {
        bool mouseClicked = Input.GetMouseButtonDown(0);
        bool mouseHeld = Input.GetMouseButton(0);
        bool mouseReleased = Input.GetMouseButtonUp(0);
        if (mouseClicked)
        {
            mousePosition = Input.mousePosition;
            mousePosition.z = 5;
            transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
            positions = new List<Vector2>();
        }
        else if (mouseHeld)
        {
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = new Vector2(Input.mousePosition.x - mousePosition.x, Input.mousePosition.y - mousePosition.y);

            mousePosition = Input.mousePosition;
            mousePosition.z = 5;
            positions.Add(new Vector2(mousePosition.x, mousePosition.y));
            
            // Move object across XY plane
            transform.Translate(touchDeltaPosition.x * speed, touchDeltaPosition.y * speed, 0);
        }

        //Quando solta o dedo testa se o rabisco foi a figura esperada!
        else if (mouseReleased)
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
        float minX = positions[0].x;
        float maxX = positions[positions.Count - 1].x;
        float minY = positions[0].y;
        float maxY = positions[positions.Count - 1].y;
        pontoMin.text = "Min: " + minY.ToString();
        pontoMax.text = "Max: " + maxY.ToString();
        if (Mathf.Abs(maxY - minY) <= Mathf.Abs(maxX - minX))
            return true;
        return false;
    }

    private bool EVertical(List<Vector2> positions)
    {
        float minX = positions[0].x;
        float maxX = positions[positions.Count - 1].x;
        float minY = positions[0].y;
        float maxY = positions[positions.Count - 1].y;
        pontoMin.text = "Min: " + minY.ToString();
        pontoMax.text = "Max: " + maxY.ToString();
        if (Mathf.Abs(maxY - minY) >= Mathf.Abs(maxX - minX))
            return true;
        return false;
    }
}
