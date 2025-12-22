using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchMode : MonoBehaviour
{
    [SerializeField] GameObject m_go_ECO = null;
    [SerializeField] GameObject m_go_Comfort = null;

    private byte m_mode = 0;
    void Start()
    {
        m_go_Comfort.SetActive(false);
        m_go_ECO.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.mKey.wasPressedThisFrame)
        {
            if (m_mode == 0) 
            {
                m_go_Comfort.SetActive(true);
                m_go_ECO.SetActive(false);
                m_mode = 1;
            }
            else
            {
                m_go_Comfort.SetActive(false);
                m_go_ECO.SetActive(true);
                m_mode = 0;
            }
        }
    }
}
