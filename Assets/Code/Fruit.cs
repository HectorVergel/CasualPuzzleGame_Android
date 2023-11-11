using UnityEngine;

public class Fruit : MonoBehaviour
{
    [Header("References")]
    public Transform m_spawnPosition;
    public FRUITS m_currentFruitHolding = FRUITS.NONE;
    public SpriteRenderer m_spriteRenderer;


    private Vector2 m_firstTouchPosition;
    private Vector2 m_lastTouchPosition;
    private float m_swipeAngle;

    private Fruit m_otherFruit;
    private int m_col;
    private int m_row;

    public void InitFruit(FRUITS _fruit, int _row, int _col)
    {   if (_fruit == FRUITS.NONE) return;
    
        string l_fruit = _fruit.ToString().ToLower();
        m_spriteRenderer.sprite = GameManager.instance.GetFruitSprite(l_fruit);
        m_currentFruitHolding = _fruit;

        m_row = _row;
        m_col = _col;
    }

    public void DisableFruit()
    {
        m_spriteRenderer.sprite = null;
        m_currentFruitHolding = FRUITS.NONE;
    }

    private void OnMouseDown()
    {
        m_firstTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        m_lastTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        CalculateAngle();
    }

    private void CalculateAngle()
    {
        m_swipeAngle = Mathf.Atan2(m_lastTouchPosition.y - m_firstTouchPosition.y, m_lastTouchPosition.x - m_firstTouchPosition.x) * 180 / Mathf.PI;
        Debug.Log(m_swipeAngle);
    }

    private void HandleFruitPosOnBoard()
    {
        //TODO: Change col and row depending on the swipe
    }
}