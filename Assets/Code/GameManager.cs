using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("References")]
    public TextMeshProUGUI m_scoreGUI;
    public TextMeshProUGUI m_currentLevelGUI;

    public List<Transform> m_starsSockets = new List<Transform>();

    public Image m_starsProgressBar;

    public Transform m_goalBubble;

    public List<Sprite> m_fruitSprites = new List<Sprite>();

    public ConditionObj m_conditionPrefab;

    [Header("Levels")]

    public List<Level> m_levels = new List<Level>();


    //PRIVATE

    private int m_currentLevel = 0;
    private int m_currentScore = 0;

    private Dictionary<string, Sprite> m_sprites = new Dictionary<string, Sprite>();

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

        DontDestroyOnLoad(this);
        InitDictionary();
    }
    private void Start()
    {
        InitNewLevel();
    }
    private void InitDictionary()
    {
        foreach(Sprite _sprite in m_fruitSprites)
        {
            m_sprites.Add(_sprite.name, _sprite);
        }
    }

    private void InitNewLevel()
    {
        //reset score and level
        m_currentScore = 0;
        m_starsProgressBar.fillAmount = 0;
        UpdateScore();
        UpdateLevel();

        CreateGoal();

    }

    public void LoadLevel(int _level)
    {
        SceneManager.LoadScene("Game");
        if(_level != 0) m_currentLevel = _level - 1;
        //InitNewLevel();
    }
    
    private void CreateGoal()
    {
        foreach (Condition _condition in m_levels[m_currentLevel].m_conditions)
        {
            ConditionObj l_newCondition = Instantiate(m_conditionPrefab, m_goalBubble);
            l_newCondition.InitCondition(m_sprites[_condition.m_fruit.ToString().ToLower()], _condition.m_quantity);
        }
    }
    private void UpdateScore()
    {
        m_scoreGUI.text = m_currentScore.ToString();
    }

    private void UpdateLevel()
    {
        m_currentLevelGUI.text = (m_currentLevel + 1).ToString();
    }
    //GETTERS / SETTERS

    public void AddScore(int _score)
    {
        m_currentScore += _score;
        UpdateScore();
    }

    public int GetScore()
    {
        return m_currentScore;
    }

    public void AddLevel()
    {
        m_currentLevel++;
    }

    public Sprite GetFruitSprite(string _fruit)
    {
        return m_sprites[_fruit];
    }
}

[System.Serializable]
public struct Condition
{
    public FRUITS m_fruit;
    public int m_quantity;
}

public enum FRUITS
{
    PEAR,
    BANANA,
    BLUEBERRY,
    GRAPE,
    APPLE,
    ORANGE,
    STRAWBERRY,
    NONE
               

}
