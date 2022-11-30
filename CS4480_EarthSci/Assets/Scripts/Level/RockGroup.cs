using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGroup : MonoBehaviour
{
    public Rock.RockType rockType;

    [SerializeField]
    private bool[] highlightedUITools = new bool[3];
    public enum AcidReaction { None, Strong, Weak };
    public AcidReaction reactionType;

    public bool[] getUsableTools()
    {
        return highlightedUITools;
    }
}
