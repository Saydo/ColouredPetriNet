using System;
using System.Collections;
using System.Collections.Generic;

namespace ColouredPetriNet.Container.ColouredPetriNet
{
    public partial class ColouredPetriNet
    {
        private IdGenerator _idGenerator;
        private IdGenerator _typeGenerator;

        public ColouredPetriNet()
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

        protected ColouredPetriNet(TypeStorage types, StateStorage states,
            TransitionStorage transitions, MarkerStorage markers, LinkStorage links,
            MoveRuleStorage moveRules, AccumulateRuleStorage prevAccRules,
            AccumulateRuleStorage nextAccRules)
        {
            _idGenerator = new IdGenerator(-1);
            _typeGenerator = new IdGenerator(-1);
            this.Types = types;
            this.States = states;
            this.Transitions = transitions;
            this.Markers = markers;
            this.Links = links;
            this.MoveRules = moveRules;
            this.PrevAccumulateRules = prevAccRules;
            this.NextAccumulateRules = nextAccRules;
        }

        public int GetTypeId<T>()
        {
            int type = States.GetTypeId<T>();
            if (type >= 0)
                return type;
            type = Transitions.GetTypeId<T>();
            if (type >= 0)
                return type;
            return Markers.GetTypeId<T>();
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
        #endregion
    }
}
