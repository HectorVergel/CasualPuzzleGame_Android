using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [Header("References")]
    public int m_height;
    public int m_width;
    public Fruit m_fruitPrefab;
    public BoardSocket m_socketPrefab;
    public BoardSocket[,] m_board;
    public Transform m_boardSpawnPos;
    [Header("Fruits")]
    public List<GameObject> m_fruitsPrefab;


    public static Board instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        m_board = new BoardSocket[m_width, m_height];
        InitBoard();

    }


    private void InitBoard()
    {
        for (int x = 0; x < m_board.GetLength(0); x++)
        {
            for (int y = 0; y < m_board.GetLength(1); y++)
            {

                CreateSocket(x, y);
            }
        }

        CheckBoard();

        //CUSTOM BOARD
        m_board[0, 0].m_fruitHolding.DisableFruit();
        m_board[0, 7].m_fruitHolding.DisableFruit(); 
        m_board[7, 0].m_fruitHolding.DisableFruit(); 
        m_board[7, 7].m_fruitHolding.DisableFruit(); 
    }

    private void CheckBoard()
    {
        for (int x = 0; x < m_board.GetLength(0); x++)
        {
            for (int y = 0; y < m_board.GetLength(1); y++)
            {
                if (!CheckIfFruitIsAvailable(x, y))
                {
                    CreateSocket(x, y, m_board[x, y].m_fruitHolding.m_type);

                }
            }
        }
    }

    private void CreateSocket(int x, int y)
    {
        BoardSocket l_socket = Instantiate(m_socketPrefab, this.gameObject.transform);
        l_socket.transform.localPosition = new Vector2(x - 3.5f, y - 3.5f);
        l_socket.InitSocket(x,y,m_fruitPrefab,GetRandomFruit());
        m_board[x, y] = l_socket;
    }

    private void CreateSocket(int x, int y, FRUITS _actualFruit)
    {
        Destroy(m_board[x, y].m_fruitHolding.gameObject);
        BoardSocket l_socket = Instantiate(m_socketPrefab, this.gameObject.transform);
        l_socket.transform.localPosition = new Vector2(x - 3.5f, y - 3.5f);
        l_socket.InitSocket(x,y,m_fruitPrefab, GetRandomFruit(_actualFruit));
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
            if (x + 1 < rows && m_board[x, y].m_fruitHolding == m_board[x + 1, y].m_fruitHolding)
            {
                l_result = false;
            }
            else if (x - 1 >= 0 && m_board[x, y].m_fruitHolding == m_board[x - 1, y].m_fruitHolding)
            {
                l_result = false;
            }
            else if (y - 1 >= 0 && m_board[x, y].m_fruitHolding == m_board[x, y - 1].m_fruitHolding)
            {
                l_result = false;
            }
            else if (y + 1 < cols && m_board[x, y].m_fruitHolding == m_board[x, y + 1].m_fruitHolding)
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
