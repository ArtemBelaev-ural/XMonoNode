﻿using UnityEngine;

namespace XMonoNode
{
    [ExecuteInEditMode]
    [NodeWidth(180)]
    [CreateNodeMenu("Events/OnUpdateParameters", 1)]
    [AddComponentMenu("Mono Node/OnUpdateParameters", 1)]
    [NodeTint(40, 60, 105)]
    public class OnUpdateParametersNode : EventNode
    {
        protected override void Init()
        {
            NodePort portIn = GetOutputPort(nameof(FlowOutput));
            if (portIn != null)
            {
                portIn.label = "OnUpdateParameters";
            }

            Name = "OnUpdateParameters";
        }

        public override object GetValue(NodePort port)
        {
            return null;
        }
    }
}
