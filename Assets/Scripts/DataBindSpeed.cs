using System;
using System.Collections;
using UnityEngine;

public class DataBindSpeed : MonoBehaviour
{
    private int m_speed = 0;
    public int Speed
    {
        get { return m_speed; }
    }
    void Start()
    {
        StartCoroutine(UpdateSpeedRoutine());
    }

    private IEnumerator UpdateSpeedRoutine()
    {
        yield return new WaitForSeconds(2.5f);
        while (true)
        {
            m_speed = UnityEngine.Random.Range(80, 101);

            yield return new WaitForSeconds(0.2f);
        }
    }
}
