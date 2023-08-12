using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HoverMovementConfig", menuName = "ScriptableObjects/Hover Movement Config", order = 1)]
public class HoverMovementConfig : ScriptableObject
{
    [SerializeField][Min(0)] public float boosterStrength;
    [SerializeField] public float moveSpeed;
}
