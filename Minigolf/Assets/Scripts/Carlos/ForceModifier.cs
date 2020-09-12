using System;
using UnityEngine;

public class ForceModifier : MonoBehaviour
{
    [SerializeField] private Transform  m_marker    = null;
    [SerializeField] private float      m_range     = 100;
    [SerializeField] private float      m_speed     = 0;

    public Action<float> onComplete = null;

    private bool    m_play  = false;
    private int     m_dir   = 1;
    private float   m_angle = 0;

    private void Awake()
    {
        m_marker.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!m_play)
            return;

        m_angle = m_marker.transform.eulerAngles.z;

        m_angle = WrapAngle(m_angle);

        if (m_dir == 1 && m_angle >= m_range)
            m_dir = -1;

        if (m_dir == -1 && m_angle <= m_range * -1)
            m_dir = 1;

        m_marker.Rotate(Vector3.forward, m_speed * Time.deltaTime * m_dir);

        if (Input.GetMouseButton(0))
            Stop();

    }

    private float WrapAngle(float angle)
    {
        angle %= 360;

        if (angle > 180)
            return angle - 360;

        return angle;
    }

    public void Play(Action<float> onComplete)
    {
        this.onComplete = onComplete;
        m_marker.transform.rotation = Quaternion.identity;
        m_marker.gameObject.SetActive(true);
        m_play = true;
    } 

    public void Stop()
    {
        m_play = false;
        m_marker.gameObject.SetActive(false);
        onComplete(m_angle / m_range);
    }
}
