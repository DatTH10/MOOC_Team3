using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GaugeComfort : MonoBehaviour
{
    [SerializeField] DataBindSpeed m_databindSpeed = null;
    [SerializeField] Text m_textSpeed = null;
    [SerializeField] Text m_textSpeed_Big = null;

    [SerializeField] Image m_ImageSpeed = null;
    [SerializeField] Image m_ImageBarSpeed = null;


    private int m_curSpeed = 0;
    private float m_fillAmount = 0;
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

            m_fillAmount = 0.008f * m_curSpeed - 0.24f;
            m_ImageSpeed.fillAmount = m_fillAmount;

            float tmp_X = -1.55f * m_curSpeed - 220f;
            float tmp_y = 3.3f * m_curSpeed - 141f;
            m_ImageBarSpeed.rectTransform.localPosition = new Vector3(tmp_X, tmp_y, 0);
        }
    }
}
