using UnityEngine;

public class BoardSocket : MonoBehaviour
{

    public Fruit m_fruitHolding;
    private int m_col;
    private int m_row;

    public void InitSocket(int _col, int _row, Fruit _prefab, FRUITS _type)
    {
        this.m_col = _col;
        this.m_row = _row;
        this.m_fruitHolding = Instantiate(_prefab, transform.position, Quaternion.identity);
        this.m_fruitHolding.InitFruit(_type, m_col, m_row);
        
    }



}