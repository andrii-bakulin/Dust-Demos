﻿using UnityEditor;

namespace Dust.DustEditor
{
    [CustomEditor(typeof(ConeGizmo))]
    [CanEditMultipleObjects]
    public class ConeGizmoEditor : AbstractGizmoEditor
    {
        protected DuProperty m_Radius;
        protected DuProperty m_Height;
        protected DuProperty m_Center;
        protected DuProperty m_Direction;

        //--------------------------------------------------------------------------------------------------------------

        [MenuItem("Dust/Gizmos/Cone")]
        [MenuItem("GameObject/Dust/Gizmos/Cone")]
        public static void AddComponentToSelectedObjects()
        {
            AddGizmoToSelectedOrNewObject(typeof(ConeGizmo));
        }

        //--------------------------------------------------------------------------------------------------------------

        protected override void InitializeEditor()
        {
            base.InitializeEditor();

            m_Radius = FindProperty("m_Radius", "Radius");
            m_Height = FindProperty("m_Height", "Height");
            m_Center = FindProperty("m_Center", "Center");
            m_Direction = FindProperty("m_Direction", "Direction");
        }

        public override void OnInspectorGUI()
        {
            InspectorInitStates();

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            PropertyExtendedSlider(m_Radius, 0f, 10f, 0.01f);
            PropertyExtendedSlider(m_Height, 0f, 10f, 0.01f);
            PropertyField(m_Center);
            PropertyField(m_Direction);
            Space();
            PropertyField(m_Color);
            PropertyField(m_GizmoVisibility);

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            InspectorCommitUpdates();
        }
    }
}
