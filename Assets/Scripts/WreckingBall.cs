using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBall : MonoBehaviour
{
    public Transform m_WreckingBallTop;

    public Transform m_LeverPivot;

    public float m_speed;

    public Vector3 m_direction;

    // Update is called once per frame
    void Update()
    {
        if(m_LeverPivot.eulerAngles.x > 15 && m_LeverPivot.eulerAngles.x < 180)
        {
            m_WreckingBallTop.Translate(m_direction * Time.deltaTime * m_speed);
        }
        else if(m_LeverPivot.eulerAngles.x > 180 && m_LeverPivot.eulerAngles.x < 345)
        {
            m_WreckingBallTop.Translate(-m_direction * Time.deltaTime * m_speed);
        }
    }
}
