using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// ������������� ����, ������������� �� ����� distance
    /// </summary>
    [AddComponentMenu("X Sound Node/Get Time", 202)]
    [CreateNodeMenu("Sound/Get Time", 202)]
    [NodeWidth(140)]
    public class XSoundNodeGetTime : XSoundNodeSimple
    {
        [Output]
        public float                    time = 0.0f;

        [Input(connectionType: ConnectionType.Override, typeConstraint: TypeConstraint.Inherited), Hiding]
        public bool                     normalized = false;

        private void Reset()
        {
            Name = "Get Time";
        }

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(time))
            {
                time = 0.0f;

                AudioSources sources = GetAudioInput();
                normalized = GetInputValue(nameof(normalized), normalized);
                if (sources.List.Count != 0)
                {
                    AudioSource source = sources.List[sources.List.Count-1];
                    if (source.isPlaying &&
                        source.clip != null &&
                        Mathf.Approximately(source.clip.length, 0.0f) == false)
                    {
                        time = source.time;
                        time /= normalized ? source.clip.length : 1.0f;
                    }
                }
                return time;
            }

            return null;
        }
    }
}
