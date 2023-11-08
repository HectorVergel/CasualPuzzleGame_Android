using UnityEngine;

public class BoardSocket : MonoBehaviour
{
    [Header("References")]
    public Transform m_spawnPosition;
    public FRUITS m_currentFruitHolding = FRUITS.NONE;
    public SpriteRenderer m_spriteRenderer;

    public void InitSocketWithFruit(FRUITS _fruit)
    {   if (_fruit == FRUITS.NONE) return;
    
        string l_fruit = _fruit.ToString().ToLower();
        m_spriteRenderer.sprite = GameManager.instance.GetFruitSprite(l_fruit);
        m_currentFruitHolding = _fruit;
    }

    public void DisableSocket()
    {
        m_spriteRenderer.sprite = null;
        m_currentFruitHolding = FRUITS.NONE;
    }
}