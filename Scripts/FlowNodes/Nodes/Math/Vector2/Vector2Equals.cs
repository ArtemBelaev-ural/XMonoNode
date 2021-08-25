﻿using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Vector2/Equals", 14)]
    [NodeWidth(150)]
    public class Vector2Equals : MonoNode
    {
        [Input(connectionType: ConnectionType.Override)]
        public Vector2  a;

        [Input(connectionType: ConnectionType.Override)]
        public Vector2  b;

        [Output] public bool equals;

        public override object GetValue(NodePort port)
        {
            return Vector2.Equals(GetInputValue(nameof(a), a), GetInputValue(nameof(b), b));
        }
    }
}
