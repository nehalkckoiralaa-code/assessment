// using UnityEngine;

// public class Interactable : MonoBehaviour
// {
//     public string title;

//     [TextArea]
//     public string description;

//     [HideInInspector]
//     public bool hasBeenFound = false;
// }

using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string title;

    [TextArea]
    public string description;

    public bool isQuizBoard = false;

    [HideInInspector]
    public bool hasBeenFound = false;
}