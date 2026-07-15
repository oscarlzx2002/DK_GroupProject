using UnityEngine;

public class LadderBehaviour : MonoBehaviour
{
    
    [SerializeField] private PlatformEffector2D pE;
    [SerializeField] private Movement movement;

    public bool isClimbing;
    public bool isLadder;


    private void Start()
    {
        pE = GetComponent<PlatformEffector2D>();
    }
    void Update()
    {

    }

    void OnClimb()
    {
        pE.rotationalOffset = 180f;
    }
    void OnClimbEnd()
    {
        pE.rotationalOffset = 0f;
    }

}
