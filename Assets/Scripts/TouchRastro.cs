using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class TouchRastro : MonoBehaviour {
    public TrailRenderer tr;
    public List<Vector2> positions;
    public int comprimentoMin = 5;
    private int indexEnemyDestroy;
    public GameManager.TipoFigura tipoFigura = GameManager.TipoFigura.HOR;
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
            tipoFigura = CheckRabisco(positions);
            DestroyEnemy();
                
        }
    }

    
    private void DestroyEnemy()
    {
        GameObject enemyToDestroy = FindEnemyToDestroy();
        if (enemyToDestroy != null)
        {
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
        float min = positions[0].y;
        float max = positions[positions.Count - 1].y ;
        if (Mathf.Abs(max - min) <= 80 && CalcComprimento(positions) > comprimentoMin)
            return true;
        return false;
    }

    private bool EVertical(List<Vector2> positions)
    {
        float min = positions[0].x;
        float max = positions[positions.Count - 1].x;
        if (Mathf.Abs(max - min) <= 60 && CalcComprimento(positions) > comprimentoMin)
            return true;
        return false;
    }

    private int CalcComprimento(List<Vector2> positions)
    {
        return positions.Count;
    }
}
