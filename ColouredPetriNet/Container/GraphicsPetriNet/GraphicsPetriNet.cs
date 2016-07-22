using System.Collections.Generic;

namespace ColouredPetriNet.Container.GraphicsPetriNet
{
    public partial class GraphicsPetriNet
    {
        public enum ItemType { Link, Marker = 100, Transition = 200, State = 300 };

        private const int _linkZ = 1;
        private const int _stateZ = 2;
        private IdGenerator _idGenerator;
        private IdGenerator _typeGenerator;

        public GraphicsPetriNet()
        {
            _idGenerator = new IdGenerator(-1);
            _typeGenerator = new IdGenerator(-1);
            this.Types = new TypeStorage(this);
            this.States = new StateStorage(this);
            this.Transitions = new TransitionStorage(this);
            this.Markers = new MarkerStorage(this);
            this.Links = new LinkStorage(this);
            this.MoveRules = new MoveRuleStorage();
            this.PrevAccumulateRules = new AccumulateRuleStorage();
            this.NextAccumulateRules = new AccumulateRuleStorage();
        }

        /*
        void SetDefaultStyle();
        void RemoveSelectedItems();
        void Select(int x, int y);
        void Select(int x, int y, int w, int h);
        void SelectItems();
        void Deselect(int x, int y);
        void Deselect(int x, int y, int w, int h);
        void DeselectItems();
        void Move(int dx, int dy);
        bool Move(int dx, int dy, int id);
        void MoveSelectedItems(int dx, int dy);
        bool Serialize(string filePath);
        bool Deserialize(string filePath);
        void SetSelectionArea(int x, int y, int w, int h);
        void UpdateSelectionArea(int w, int h);
        void UpdateSelectionAreaByPos(int x, int y);
        void HideSelectionArea();
        void Draw(Graphics graphics);
        */

        public int GenerateItemId()
        {
            return _idGenerator.Next();
        }

        public void Clear()
        {
            this.Types.Clear();
        }

        #region Helpful Functions
        private static void RemoveFromList<T>(List<T> list, List<int> indexList)
        {
            for (int i = indexList.Count - 1; i >= 0; --i)
            {
                list.RemoveAt(indexList[i]);
                for (int j = i - 1; j >= 0; --j)
                {
                    if (indexList[j] > indexList[i])
                    {
                        --indexList[j];
                    }
                }
            }
        }

        private static bool RemoveFromIdList(List<int> idList, int id)
        {
            for (int i = 0; i < idList.Count; ++i)
            {
                if (idList[i] == id)
                {
                    idList.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}