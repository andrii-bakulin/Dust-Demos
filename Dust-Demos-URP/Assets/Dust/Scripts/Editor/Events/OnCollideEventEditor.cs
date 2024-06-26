using UnityEngine;
using UnityEditor;

namespace Dust.DustEditor
{
    public abstract class OnCollideEventEditor : OnAbstractEventEditor
    {
        protected DuProperty m_ObjectTags;
        protected DuProperty m_TagProcessingMode;

        protected DuProperty m_OnEnter;
        protected DuProperty m_OnStay;
        protected DuProperty m_OnExit;

        protected override void InitializeEditor()
        {
            base.InitializeEditor();

            m_ObjectTags = FindProperty("m_ObjectTags", "Object Tags");
            m_TagProcessingMode = FindProperty("m_TagProcessingMode", "Tag Check");

            m_OnEnter = FindProperty("m_OnEnter", "On Enter Callbacks");
            m_OnStay = FindProperty("m_OnStay", "On Stay Callbacks");
            m_OnExit = FindProperty("m_OnExit", "On Exit Callbacks");
        }

        public override void OnInspectorGUI()
        {
            InspectorInitStates();

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            DustGUI.Header("Tag");
            PropertyField(m_TagProcessingMode);

            var tagProcessingMode = (OnCollideEvent.TagProcessingMode) m_TagProcessingMode.valInt;

            if (tagProcessingMode != OnCollideEvent.TagProcessingMode.Ignore)
            {
                PropertyField(m_ObjectTags);
            }

            Space();

            var titleOnEnter = "Enter" + (m_OnEnter.valUnityEvent.arraySize > 0 ? " (" + m_OnEnter.valUnityEvent.arraySize + ")" : "");
            var titleOnStay  = "Stay"  + (m_OnStay.valUnityEvent.arraySize  > 0 ? " (" + m_OnStay.valUnityEvent.arraySize  + ")" : "");
            var titleOnExit  = "Exit"  + (m_OnExit.valUnityEvent.arraySize  > 0 ? " (" + m_OnExit.valUnityEvent.arraySize  + ")" : "");

            var tabIndex = DustGUI.Toolbar("OnCollideEvent.Events", new[] {titleOnEnter, titleOnStay, titleOnExit});

            switch (tabIndex)
            {
                case 0: PropertyField(m_OnEnter); break;
                case 1: PropertyField(m_OnStay); break;
                case 2: PropertyField(m_OnExit); break;
            }

            Space();

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            InspectorCommitUpdates();
        }
    }
}
