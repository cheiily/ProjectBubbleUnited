using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TransparentEnemyMaterialsPreset", menuName = "Scriptable Objects/TransparentEnemyMaterialsPreset")]
public class TransparentEnemyMaterialsPreset : ScriptableObject {
    // transparent materials, mapping 0=0, 1=1, 2=2
    public List<Material> materials;
    // dead materials, mapping 0=0 dead, 1=0 dead transparent
    public List<Material> deadMaterials;
}
