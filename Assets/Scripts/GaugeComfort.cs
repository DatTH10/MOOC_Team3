using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GaugeComfort : MonoBehaviour
{
    [SerializeField] DataBindSpeed m_databindSpeed = null;
    [SerializeField] Text m_textSpeed = null;
    [SerializeField] Text m_textSpeed_Big = null;

    private int m_curSpeed = 0;
    void Start()
    {
        m_textSpeed.text = "0";
        m_textSpeed_Big.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if (m_curSpeed != m_databindSpeed.Speed)
        {
            m_curSpeed = m_databindSpeed.Speed;
            m_textSpeed.text = m_curSpeed.ToString();
            m_textSpeed_Big.text = m_curSpeed.ToString();
        }
    }
}
