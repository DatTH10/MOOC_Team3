using UnityEngine;

public class RoadMove : MonoBehaviour
{
    [SerializeField] private GameObject m_go_Left = null;
    [SerializeField] private GameObject m_go_Right = null;
    [SerializeField] private DataBindSpeed m_DataBindSpeed = null;
    private Renderer m_Renderer_Left;
    private Renderer m_Renderer_Right;
    private float m_Offset;
    void Start()
    {
        m_Renderer_Left = m_go_Left.GetComponent<Renderer>();
        m_Renderer_Right = m_go_Right.GetComponent<Renderer>();
    }

    void Update()
    {
        if(m_DataBindSpeed.isMove)
        {
            m_Offset += -Time.deltaTime * 0.25f;
            m_Renderer_Left.material.mainTextureOffset = new Vector2(0, m_Offset);
            m_Renderer_Right.material.mainTextureOffset = new Vector2(0, m_Offset);
        }
    }
}