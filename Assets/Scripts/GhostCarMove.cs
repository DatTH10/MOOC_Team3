using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostCarMove : MonoBehaviour
{
    public List<Vector3> points;
    private float speed = 1f;
    private float reachDistance = 0.05f;

    private int currentIndex = 0;

    [SerializeField] Outline m_OutLine = null;
    [SerializeField] GameObject m_MainCar = null;

    private Vector3 m_MainCar_Left = new Vector3 (0f, 0f, 0f);
    private Vector3 m_MainCar_Right = new Vector3 (0f, 0f, 0f);
    private Vector3 m_MainCar_Top = new Vector3 (0f, 0f, 0f);

    void Start()
    {
        currentIndex = 1;
        m_OutLine.enabled = false;

        StartCoroutine(Move());

        m_MainCar_Left = m_MainCar.transform.localPosition + new Vector3(0f, 0f, 0.5f);
        m_MainCar_Right = m_MainCar.transform.localPosition + new Vector3(0f, 0f, -0.5f);
        m_MainCar_Top = m_MainCar.transform.localPosition + new Vector3(2f, 0f, 0f);

    }

    private void FixedUpdate()
    {
        if (ReturnDistance())
        {
            m_OutLine.enabled = true;
        }
        else
        {
            m_OutLine.enabled = false;
        }
    }

    private bool ReturnDistance()
    {
        float distance1 = (transform.localPosition - m_MainCar_Left).magnitude;
        float distance2 = (transform.localPosition - m_MainCar_Right).magnitude;
        float distance3 = (transform.localPosition - m_MainCar_Top).magnitude;
        if(distance1 < 1.5f || distance2 < 1.5f || distance3 < 2f)
        {
            return true;
        }
        return false;
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(2.5f);
        transform.localPosition = points[0];
        while (true)
        {
            Vector3 target = points[currentIndex];

            while (Vector3.Distance(transform.localPosition, target) > reachDistance)
            {
                transform.localPosition = Vector3.MoveTowards(
                    transform.localPosition,
                    target,
                    speed * Time.deltaTime
                );
                yield return null;
            }
            transform.localPosition = target;

            currentIndex++;

            if (currentIndex >= points.Count)
            {
                currentIndex = 0;
            }

            yield return null;
        }
    }
}
