﻿using UnityEditor;

namespace Dust.DustEditor
{
    [CustomEditor(typeof(PyramidGizmo))]
    [CanEditMultipleObjects]
    public class PyramidGizmoEditor : AbstractGizmoEditor
    {
        protected DuProperty m_Radius;
        protected DuProperty m_Height;
        protected DuProperty m_Faces;
        protected DuProperty m_Center;
        protected DuProperty m_Direction;

        //--------------------------------------------------------------------------------------------------------------

        [MenuItem("Dust/Gizmos/Pyramid")]
        [MenuItem("GameObject/Dust/Gizmos/Pyramid")]
        public static void AddComponentToSelectedObjects()
        {
            AddGizmoToSelectedOrNewObject(typeof(PyramidGizmo));
        }

        //--------------------------------------------------------------------------------------------------------------

        protected override void InitializeEditor()
        {
            base.InitializeEditor();

            m_Radius = FindProperty("m_Radius", "Radius");
            m_Height = FindProperty("m_Height", "Height");
            m_Faces = FindProperty("m_Faces", "Faces");
            m_Center = FindProperty("m_Center", "Center");
            m_Direction = FindProperty("m_Direction", "Direction");
        }

        public override void OnInspectorGUI()
        {
            InspectorInitStates();

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            PropertyExtendedSlider(m_Radius, 0f, 10f, 0.01f);
            PropertyExtendedSlider(m_Height, 0f, 10f, 0.01f);
            PropertyExtendedIntSlider(m_Faces, 3, 64, 1, 3, 256);
            PropertyField(m_Center);
            PropertyField(m_Direction);
            Space();
            PropertyField(m_Color);
            PropertyField(m_GizmoVisibility);

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            // Validate & Normalize Data

            if (m_Faces.isChanged)
                m_Faces.valInt = PyramidGizmo.NormalizeFaces(m_Faces.valInt);

            InspectorCommitUpdates();
        }
    }
}
