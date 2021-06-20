using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HadeInstruction : MonoBehaviour
{
    public GameObject instruction;

    public void ClickBegin()
    {
        instruction.SetActive(false);
    }
    
}
