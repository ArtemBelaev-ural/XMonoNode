using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using XMonoNode;
using FlowNodesEditor;

namespace XMonoNodeEditor
{
    [CustomPropertyDrawer(typeof(PathToAudioClipAttribute))]
    public class PathToAudioClipAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {

            if (property == null)
            {
                return;
            }

            EditorGUI.BeginProperty(position, label, property);

            int buttonWidth = 16;

            position.width -= buttonWidth - 2;
            // Draw label


            // Don't make child fields be indented
            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            EditorGUI.PropertyField(position, property, label);

            if (!string.IsNullOrEmpty(property.stringValue))
            {
                position.y += 1;
                position.x += position.width + 1;
                position.width = buttonWidth;
                position.height = buttonWidth;
                string path = "Sounds/" + property.stringValue;
                AudioClip clip = Resources.Load<AudioClip>(path);

                bool guiEnabled = GUI.enabled;
    

                GUI.enabled = clip != null;
                string tooltip = clip != null ? "play" : ("No audio clip at path: \"" + path + "\"");
                if (GUI.Button(position, new GUIContent("", tooltip), clip != null ? NodeEditorResources.styles.playButton : NodeEditorResources.styles.errorButton))
                {
                    AudioSource.PlayClipAtPoint(clip, Vector3.zero);
                }

                // GUI.contentColor = color;
                GUI.enabled = guiEnabled;
            }

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }
    }
}
