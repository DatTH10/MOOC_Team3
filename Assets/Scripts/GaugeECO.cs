using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GaugeECO : MonoBehaviour
{
    [SerializeField] DataBindSpeed m_databindSpeed = null;
    [SerializeField] Text m_textSpeed = null;
    [SerializeField] Image m_LeftAnalog = null;
    [SerializeField] Image m_RightAnalog = null;
    [SerializeField] Image m_Needle_Left = null;
    [SerializeField] Image m_Needle_Right = null;
    private int m_curSpeed = 0;

    private float m_fillAmount = 0;

    private void Start()
    {
        m_textSpeed.text = "0";
        StartCoroutine(FillRoutine(m_LeftAnalog));
        StartCoroutine(FillRoutine(m_RightAnalog));

        StartCoroutine(RotateRoutineNeedle(m_Needle_Left, 74f, -14.5f, 0.6f));
        StartCoroutine(RotateRoutineNeedle(m_Needle_Right, 93f, 61.5f, 0.6f));
    }
    private void Update()
    {
        if (m_curSpeed != m_databindSpeed.Speed)
        {
            m_curSpeed = m_databindSpeed.Speed;
            m_textSpeed.text = m_curSpeed.ToString();

            m_fillAmount = 67f / 20000 * m_curSpeed + 0.132f;
            m_LeftAnalog.fillAmount = m_fillAmount;
            m_RightAnalog.fillAmount = m_fillAmount;

            float tmp_left_angle = -1.15f * m_curSpeed + 77.5f;
            float tmp_right_angle = -1.125f * m_curSpeed + 151.5f;
            m_Needle_Left.rectTransform.localRotation = Quaternion.Euler(0f, 0f, tmp_left_angle);
            m_Needle_Right.rectTransform.localRotation = Quaternion.Euler(0f, 0f, tmp_right_angle);
        }
    }

    private IEnumerator FillRoutine(Image arg_img)
    {
        yield return StartCoroutine(FillAmount(arg_img, 0f, 1f, 0.8f));

        yield return StartCoroutine(FillAmount(arg_img, 1f, 0f, 0.8f));

        yield return StartCoroutine(FillAmount(arg_img, 0f, 0.4f, 0.6f));

        StopAllCoroutines();
    }
    private IEnumerator FillAmount(Image arg_img, float arg_from, float arg_to, float arg_duration)
    {
        float elapsed = 0f;

        while (elapsed < arg_duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / arg_duration;

            arg_img.fillAmount = Mathf.Lerp(arg_from, arg_to, t);
            yield return null;
        }
        arg_img.fillAmount = arg_to;
    }

    private IEnumerator RotateRoutineNeedle(Image arg_img, float arg_startZ, float arg_targetZ, float arg_duration)
    {
        yield return new WaitForSeconds(1.6f);
        Quaternion from = Quaternion.Euler(0f, 0f, arg_startZ);
        Quaternion to = Quaternion.Euler(0f, 0f, arg_targetZ);

        float elapsed = 0f;

        while (elapsed < arg_duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / arg_duration;

            arg_img.rectTransform.localRotation = Quaternion.Lerp(from, to, t);
            yield return null;
        }

        arg_img.rectTransform.localRotation = to;
    }
}
