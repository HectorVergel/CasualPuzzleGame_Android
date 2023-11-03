using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConditionObj : MonoBehaviour
{
    [Header("References")]
    public Image m_image;
    public TextMeshProUGUI m_number;

    public void InitCondition(Sprite _sprite, int _number)
    {
        m_image.sprite = _sprite;
        m_number.text = _number.ToString();
    }
}
