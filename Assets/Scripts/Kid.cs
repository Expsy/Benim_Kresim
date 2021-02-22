using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Kid", menuName = "ScriptableObjects/Kid", order = 1)]
public class Kid : ScriptableObject
{
        
        public string kidMame;
        public bool dirty;
        public int dirtyNailCount;

}
