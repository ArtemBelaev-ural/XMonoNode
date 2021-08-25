﻿using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Vector2/GetY", -8)]
    [NodeWidth(150)]
    public class Vector2GetY : MonoNode
    {
        [Input(connectionType: ConnectionType.Override)]
        public Vector2  a;

        [Output] public float   y;

        NodePort inputPort;

        protected override void Init()
        {
            base.Init();
            inputPort = GetInputPort(nameof(a));
        }

        public override object GetValue(NodePort port)
        {
            return inputPort.GetInputValue(a).y;
        }
    }
}
