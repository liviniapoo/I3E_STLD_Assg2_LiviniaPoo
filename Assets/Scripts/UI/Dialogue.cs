/*
 * Author: Livinia Poo
 * Date: 01/07/2024
 * Description: 
 * Dialogue pop-ups UI
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System .Serializable]
public class Dialogue
{
    public string[] names;

    [TextArea(3,10)]
    public string[] sentences;
}
