using UnityEngine;
using UnityEngine.UI;

public class GaugeECO : MonoBehaviour
{
    [SerializeField] DataBindSpeed m_databindSpeed = null;
    [SerializeField] Text m_textSpeed = null;
    [SerializeField] Image m_LeftAnalog = null;
    [SerializeField] Image m_RightAnalog = null;
    private int m_curSpeed = 0;

    private float m_fillAmount = 0;

    private void Update()
    {
        if (m_curSpeed != m_databindSpeed.Speed)
        {
            m_curSpeed = m_databindSpeed.Speed;
            m_textSpeed.text = m_curSpeed.ToString();

            m_fillAmount = 67f/20000 * m_curSpeed +0.132f;
            m_LeftAnalog.fillAmount = m_fillAmount;
            m_RightAnalog.fillAmount = m_fillAmount;
        }
    }
}
