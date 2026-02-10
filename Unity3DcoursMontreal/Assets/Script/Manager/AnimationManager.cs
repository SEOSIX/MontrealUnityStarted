using System;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    
    [SerializeField]private Animator animator;

    public static bool isWalking;
    public static float walkSpeed;
    public static float rotationPlayerValue;
    public static float cameraMovementValue;
    
    public static event Action OnWalkAnimationFinished;
    //regarder quel type d'Action mettre d'autre pour avoir des mouvement fluides 
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
}
