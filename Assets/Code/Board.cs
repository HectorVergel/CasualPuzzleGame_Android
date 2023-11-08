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

                CreateFruitInBoard(x, y);
            }
        }

        CheckBoard();

        //CUSTOM BOARD
        m_board[0, 0].DisableSocket();
        m_board[0, 7].DisableSocket();
        m_board[7, 0].DisableSocket();
        m_board[7, 7].DisableSocket();
    }

    private void CheckBoard()
    {
        for (int x = 0; x < m_board.GetLength(0); x++)
        {
            for (int y = 0; y < m_board.GetLength(1); y++)
            {
                if (!CheckIfFruitIsAvailable(x, y))
                {
                    CreateFruitInBoard(x, y, m_board[x, y].m_currentFruitHolding);


                }
            }
        }



    }

    private void CreateFruitInBoard(int x, int y)
    {
        BoardSocket l_socket = Instantiate(m_socketPrefab, this.gameObject.transform);
        l_socket.transform.localPosition = new Vector2(x - 3.5f, y - 3.5f);
        l_socket.InitSocketWithFruit(GetRandomFruit());
        m_board[x, y] = l_socket;
    }

    private void CreateFruitInBoard(int x, int y, FRUITS _actualFruit)
    {
        Destroy(m_board[x, y].gameObject);
        BoardSocket l_socket = Instantiate(m_socketPrefab, this.gameObject.transform);
        l_socket.transform.localPosition = new Vector2(x - 3.5f, y - 3.5f);
        l_socket.InitSocketWithFruit(GetRandomFruit(_actualFruit));
        m_board[x, y] = l_socket;
    }
    private bool CheckIfFruitIsAvailable(int x, int y)
    {
        int rows = m_board.GetLength(0);
        int cols = m_board.GetLength(1);
        bool l_result = false;

        if (x >= 0 && x < rows && y >= 0 && y < cols && x + 2 < rows && y < cols)
        {
            // Comprobar la fruta a la derecha
            if (x + 1 < rows && m_board[x, y].m_currentFruitHolding == m_board[x + 1, y].m_currentFruitHolding)
            {
                l_result = false;
            }
            else if (x - 1 >= 0 && m_board[x, y].m_currentFruitHolding == m_board[x - 1, y].m_currentFruitHolding)
            {
                l_result = false;
            }
            else if (y - 1 >= 0 && m_board[x, y].m_currentFruitHolding == m_board[x, y - 1].m_currentFruitHolding)
            {
                l_result = false;
            }
            else if (y + 1 < cols && m_board[x, y].m_currentFruitHolding == m_board[x, y + 1].m_currentFruitHolding)
            {
                l_result = false;
            }
            else 
            { 
                return true; 
            }


        }

        return l_result;
    }

    private FRUITS GetRandomFruit()
    {
        return (FRUITS)typeof(FRUITS).GetRandomEnumValue();
    }

    private FRUITS GetRandomFruit(FRUITS _fruit)
    {
        FRUITS l_fruit = (FRUITS)typeof(FRUITS).GetRandomEnumValue();
        if (l_fruit != _fruit)
        {
            return (FRUITS)typeof(FRUITS).GetRandomEnumValue();
        }
        else
        {
            return GetRandomFruit(_fruit);
        }

    }
}
