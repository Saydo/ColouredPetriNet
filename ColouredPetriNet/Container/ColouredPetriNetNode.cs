using System;
using System.Collections.Generic;

namespace ColouredPetriNet.Container
{
    public class ColouredPetriNetNode<T> : IColouredPetriNetNode<T>
    {
        private List<int> _inputLinkNodes;
        private List<int> _outputLinkNodes;

        public int Id { get; private set; }
        public T Value { get; private set; }
        public List<int> InputLinkNodes { get { return _inputLinkNodes; } }
        public List<int> OutputLinkNodes { get { return _outputLinkNodes; } }

        public ColouredPetriNetNode()
        {
            Id = -1;
            _inputLinkNodes = new List<int>();
            _outputLinkNodes = new List<int>();
        }

        public ColouredPetriNetNode(int id, T value)
        {
            Id = id;
            Value = value;
            _inputLinkNodes = new List<int>();
            _outputLinkNodes = new List<int>();
        }

        public Type GetValueType()
        {
            return Value.GetType();
        }

        public bool ContainsInputLinkNodes()
        {
            return (_inputLinkNodes.Count > 0);
        }

        public bool ContainsInputLinkNode(int id)
        {
            return _inputLinkNodes.Contains(id);
        }

        public bool ContainsOutputLinkNodes()
        {
            return (_outputLinkNodes.Count > 0);
        }

        public bool ContainsOutputLinkNode(int id)
        {
            return _outputLinkNodes.Contains(id);
        }

        public bool ContainsLinkNode(int id)
        {
            return (_inputLinkNodes.Contains(id) || _outputLinkNodes.Contains(id));
        }

        public void AddInputLinkNode(int id)
        {
            AddToIdList(_inputLinkNodes, id);
        }

        public void AddOutputLinkNode(int id)
        {
            AddToIdList(_outputLinkNodes, id);
        }

        public bool RemoveInputLinkNode(int id)
        {
            return _inputLinkNodes.Remove(id);
        }

        public bool RemoveOutputLinkNode(int id)
        {
            return _outputLinkNodes.Remove(id);
        }

        public void ClearInputLinkNodes()
        {
            _inputLinkNodes.Clear();
        }

        public void ClearOutputLinkNodes()
        {
            _outputLinkNodes.Clear();
        }

        protected void AddToIdList(List<int> idList, int id)
        {
            bool isFound = false;
            for (int i = 0; i < idList.Count; ++i)
            {
                if (idList[i] == id)
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                idList.Add(id);
            }
        }
    }
}
