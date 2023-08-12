using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JumpMovementConfig", menuName = "ScriptableObjects/Jump Movement Config", order = 1)]
public class JumpMovementConfig : ScriptableObject
{
    [SerializeField][Min(0)] public float jumpStrength;
    [SerializeField] public float rotateSpeed;
    [SerializeField] public float moveSpeed;
}
