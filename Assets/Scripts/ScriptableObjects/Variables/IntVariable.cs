using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Int")]
public class IntVariable : ScriptableObject, ISerializationCallbackReceiver
{
    public int initialValue;

    
    [NonSerialized]
    public int value;

    public void OnBeforeSerialize()
    {
        value = initialValue;
    }

    public void OnAfterDeserialize()
    {
        //
    }
}
