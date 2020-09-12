using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(DragListener))]
[RequireComponent(typeof(CollisionListener))]
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(ConstantForce))]
public class BallController : MonoBehaviour
{
    [SerializeField] private float          m_force         = 0.0f;
    [SerializeField] private Transform      m_visualObject  = null;
    [SerializeField] private ForceModifier  m_forceModifier = null;
    
    private DragListener        m_dragListener          = null;
    private CollisionListener   m_collisionListener     = null;
    private Rigidbody           m_rb                    = null;
    private ConstantForce       m_constanForce          = null;

    public DragListener         dragListener        { get { return m_dragListener;      } }
    public CollisionListener    collisionListener   { get { return m_collisionListener; } }
    public Rigidbody            rb                  { get { return m_rb;                } }
    public ConstantForce        constanForce        { get { return m_constanForce;      } }
    public ForceModifier        forceModifier       { get { return m_forceModifier;     } }
    public float                force               { get { return m_force;             } }
    public Transform            visualObject        { get { return m_visualObject;      } }

    private void Awake()
    {
        m_dragListener      = GetComponent<DragListener>();
        m_collisionListener = GetComponent<CollisionListener>();
        m_rb                = GetComponent<Rigidbody>();
        m_constanForce      = GetComponent<ConstantForce>();

        m_constanForce.force    = Vector3.zero;
        m_rb.useGravity         = false;
    }
}