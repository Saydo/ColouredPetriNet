using System;
using System.Collections.Generic;

namespace ColouredPetriNet.Container.GraphicsPetriNet
{
    public struct PetriNetIdConvertationRule
    {
        public enum ConvertationMode { Same, Removed, Added, New };
        public int Parameter;
        public ConvertationMode Mode;

        public int Convert(int id, int parameter = 1)
        {
            switch (Mode)
            {
                case ConvertationMode.Same:
                    return id;
                case ConvertationMode.Removed:
                    return -1;
                case ConvertationMode.Added:
                    return id + parameter;
                case ConvertationMode.New:
                    return parameter;
            }
            return -1;
        }
    }

    class PetriNetItemIdConvertationRule
    {
        public const int Removed = -1;

        public int OutputItemType;
        public List<PetriNetIdConvertationRule> ConvertationRules;
        public int InputItemType;

        // << Accumulate In Container >>
        // var accumulateRule = FindComplyAccumulateRule(StateWrapper state) // first - rule with most priority, then - with most weight
        // if (accumulate == null) -> finish acuumulate
        // << Accumulate in Rule >>
        // If !IsComply(StateWrapper state) return false
        // var idConvertationRule = FindComplyIdConvertationRule() // first - rule with most priority, then - with most weight | if not found custom -> exec default idConvertation (all old id replaced by new)
        // idConvertationRule
    }
}
