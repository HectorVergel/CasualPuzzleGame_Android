using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [Header("References")]
    public int m_height;
    public int m_width;
    public BoardSocket m_socketPrefab;
    public BoardSocket[,] m_board;
    public Transform m_boardSpawnPos;
    [Header("Fruits")]
    public List<GameObject> m_fruitsPrefab;


    private void Start()
    {
        m_board = new BoardSocket[m_height, m_width];
        InitBoard();
    }

    private void InitBoard()
    {
        for (int x = 0; x < m_board.GetLength(0); x++)
        {
            for (int y = 0; y < m_board.GetLength(1); y++)
            {
                
                BoardSocket l_socket = Instantiate(m_socketPrefab, this.gameObject.transform);
                l_socket.transform.localPosition = new Vector2(x -3.5f, y -3.5f);
                l_socket.InitSocketWithFruit((FRUITS)typeof(FRUITS).GetRandomEnumValue());
                m_board[x, y] = l_socket;   
            }
        }

        //CUSTOM BOARD

        m_board[0, 0].GetComponent<SpriteRenderer>().sprite = null;
        m_board[0, 7].GetComponent<SpriteRenderer>().sprite = null;
        m_board[7, 0].GetComponent<SpriteRenderer>().sprite = null;
        m_board[7, 7].GetComponent<SpriteRenderer>().sprite = null;

    }

    private bool CheckIfFruitIsAvailable(int x, int y)
    {
        if (m_board[x+1,y].m_currentFruitHolding == m_board[x, y].m_currentFruitHolding && m_board[x+2,y].m_currentFruitHolding == m_board[x, y].m_currentFruitHolding)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
