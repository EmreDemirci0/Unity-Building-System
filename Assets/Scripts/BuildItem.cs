using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildItem", menuName = "ScriptableObjects/BuildItem")]
public class BuildItem : ScriptableObject
{
    public GameObject mainObjectPrefab;
    public GameObject tempObjectPrefab;
    public Vector3 HandPosition;
    public Vector3 HandRotation;
    public Vector3 HandScale = Vector3.one;
}
