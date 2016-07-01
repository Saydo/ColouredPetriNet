using System;
using System.Collections.Generic;

namespace PetriNet
{
    public class PetriNetNode<T> : IPetriNetNode<T>
    {
        public PetriNetNode()
        {
            m_id = -1;
            m_inputLinkNodes = new List<int>();
            m_outputLinkNodes = new List<int>();
        }

        public PetriNetNode(int id, T value)
        {
            m_id = id;
            m_value = value;
            m_inputLinkNodes = new List<int>();
            m_outputLinkNodes = new List<int>();
        }

        public int getId()
        {
            return m_id;
        }

        public T getValue()
        {
            return m_value;
        }

        public Type getValueType()
        {
            return m_value.GetType();
        }

        public List<int> getInputLinkNodes()
        {
            return m_inputLinkNodes;
        }

        public List<int> getOutputLinkNodes()
        {
            return m_outputLinkNodes;
        }

        public bool containsInputLinkNodes()
        {
            return (m_inputLinkNodes.Count > 0);
        }

        public bool containsInputLinkNode(int id)
        {
            return m_inputLinkNodes.Contains(id);
        }

        public bool containsOutputLinkNodes()
        {
            return (m_outputLinkNodes.Count > 0);
        }

        public bool containsOutputLinkNode(int id)
        {
            return m_outputLinkNodes.Contains(id);
        }

        public bool containsLinkNode(int id)
        {
            return (m_inputLinkNodes.Contains(id) || m_outputLinkNodes.Contains(id));
        }

        public void addInputLinkNode(int id)
        {
            addToIdList(m_inputLinkNodes, id);
        }

        public void addOutputLinkNode(int id)
        {
            addToIdList(m_outputLinkNodes, id);
        }

        public bool removeInputLinkNode(int id)
        {
            return m_inputLinkNodes.Remove(id);
        }

        public bool removeOutputLinkNode(int id)
        {
            return m_outputLinkNodes.Remove(id);
        }

        public void clearInputLinkNodes()
        {
            m_inputLinkNodes.Clear();
        }

        public void clearOutputLinkNodes()
        {
            m_outputLinkNodes.Clear();
        }

        protected void addToIdList(List<int> id_list, int id)
        {
            bool is_found = false;
            for (int i = 0; i < id_list.Count; ++i)
            {
                if (id_list[i] == id)
                {
                    is_found = true;
                    break;
                }
            }
            if (!is_found)
            {
                id_list.Add(id);
            }
        }

        protected int m_id;
        protected T m_value;
        protected List<int> m_inputLinkNodes;
        protected List<int> m_outputLinkNodes;
    }
}
