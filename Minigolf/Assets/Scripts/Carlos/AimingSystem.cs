using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(LineRenderer))]
public class AimingSystem : MonoBehaviour
{
    [SerializeField] private BallController m_ball = null;

    [SerializeField] private float m_force          = 0.0f;
    [SerializeField] private float m_elevation      = 0.0f;
    [SerializeField] private float m_realDepth      = 0.0f;
    [SerializeField] private float m_timeToCreate   = 0.0f;

    private LineRenderer    m_lineRender  = null;
    private BallController  m_currentBall   = null;

    private void Awake()
    {
        m_lineRender = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        PrepareBall();
    }

    private void PrepareBall()
    {
        BallController ball = Instantiate(m_ball, transform.position, Quaternion.identity);

        ball.dragListener.onBeginDrag   += OnBeginDrag;
        ball.dragListener.onDrag        += OnDrag;
        ball.dragListener.onEndDrag     += OnEndDrag;

        ball.collisionListener.onCollisionEnter += delegate
        {
            ball.constanForce.force = Vector3.zero;
        };

        m_currentBall = ball;
    }

    private Vector3 GetMousePosition(float depth)
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = depth;

        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void UpdateLine()
    {
        m_lineRender.SetPosition(0, transform.position);
        m_lineRender.SetPosition(1, GetMousePosition( Mathf.Abs(Camera.main.transform.position.z - transform.position.z)));
    }

    private void OnBeginDrag(PointerEventData data)
    {
        m_lineRender.positionCount = 2;
    }
    private void OnDrag(PointerEventData data)
    {
        UpdateLine();
    }
    private void OnEndDrag(PointerEventData data)
    {
        // Limpiamos la linea
        m_lineRender.positionCount = 0;

        // El jugador puede controlar la fuerza en 'x' arrastrando y usando el medidor del modificador de fuerza
        // La fuerza en 'y' o la elevacion es siempre la misma
        Vector3 lastLinePoint = GetMousePosition(m_realDepth);

        // La direccion toma el angulo en 'x' y la altitud por defecto
        Vector3 dir = new Vector3(m_currentBall.transform.position.x - lastLinePoint.x, m_elevation, 0.0f);

        // 'z' es actualmente la fuerza, la fuerza hacia adelante. Definida por la diferencia en 'y'
        dir.z = Mathf.Abs(m_currentBall.transform.position.y - lastLinePoint.y) * -1.0f;

        m_currentBall.forceModifier.Play(delegate (float v)
        {
            // hit ball
            m_currentBall.rb.useGravity = true;
            m_currentBall.rb.AddForce(dir * m_force, ForceMode.Impulse);
            m_currentBall.constanForce.force = new Vector3(v * m_currentBall.force * -1.0f, 0.0f, 0.0f);

            ShootBall(v, dir);
        });
    }

    private void ShootBall(float v, Vector3 dir)
    {
        // hit ball
        m_currentBall.rb.useGravity = true;
        m_currentBall.rb.AddForce(dir * m_force, ForceMode.Impulse);
        m_currentBall.constanForce.force = new Vector3(v * m_currentBall.force * -1.0f, 0.0f, 0.0f);

        StartCoroutine(CO_CreateBallAfter(m_timeToCreate));
    }

    private IEnumerator CO_CreateBallAfter(float t)
    {
        yield return new WaitForSeconds(t);
        PrepareBall();
    }
}
