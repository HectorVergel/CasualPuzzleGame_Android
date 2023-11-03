using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/LevelObj", order = 1)]
public class Level : ScriptableObject
{
    public Condition[] m_conditions;
    public float m_starScore;
}
