using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MouseTrack : MonoBehaviour
{
    public TrailRenderer tr;
    public List<Vector2> positions;
    private int indexEnemyDestroy;
    public static GameManager.TipoFigura tipoFigura = GameManager.TipoFigura.HOR;
    private float speed = 0.03F;
    public int comprimentoMin = 5;
    Vector3 mousePosition;
    [SerializeField]
    Score score;

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
            tipoFigura = CheckRabisco(positions);
            DestroyEnemy();

        }
    }


    private void DestroyEnemy()
    {
        GameObject enemyToDestroy = FindEnemyToDestroy();
        if (enemyToDestroy != null)
        {
            score.updateScore(10);
            Destroy(enemyToDestroy);
            GameManager.filaInimigos.Remove(GameManager.filaInimigos[indexEnemyDestroy]);
        }
    }

    private GameObject FindEnemyToDestroy()
    {
        GameObject enemy = null;
        for (int i = 0; i < GameManager.filaInimigos.Count; i++)
        {
            if (GameManager.filaInimigos[i].tipoFig == tipoFigura)
            {
                enemy = GameManager.filaInimigos[i].enemy;
                indexEnemyDestroy = i;
                break;
            }
        }
        return enemy;
    }

    private GameManager.TipoFigura CheckRabisco(List<Vector2> positions)
    {

        if (Ehorizontal(positions))
            return GameManager.TipoFigura.HOR;
        else if (EVertical(positions))
            return GameManager.TipoFigura.VER;
        else
            return GameManager.TipoFigura.V;
    }

    private bool Ehorizontal(List<Vector2> positions)
    {
        float minX = positions[0].x;
        float maxX = positions[positions.Count - 1].x;
        float minY = positions[0].y;
        float maxY = positions[positions.Count - 1].y;
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
        if (Mathf.Abs(maxY - minY) >= Mathf.Abs(maxX - minX))
            return true;
        return false;
    }

    private int CalcComprimento(List<Vector2> positions)
    {
        return positions.Count;
    }
}
