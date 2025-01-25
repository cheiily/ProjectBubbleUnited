using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TransparentEnemyMaterialsPreset", menuName = "Scriptable Objects/TransparentEnemyMaterialsPreset")]
public class TransparentEnemyMaterialsPreset : ScriptableObject {
    public List<Material> materials;
}
