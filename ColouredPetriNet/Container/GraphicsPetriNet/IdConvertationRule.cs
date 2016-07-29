using System;
using System.Collections.Generic;

namespace ColouredPetriNet.Container.GraphicsPetriNet
{
    public struct IdConvertationRule
    {
        public enum ConvertationMode { Same, Removed, Added, New };
        public int Parameter;
        public ConvertationMode Mode;

        public IdConvertationRule(ConvertationMode mode, int parameter = -1)
        {
            Mode = mode;
            Parameter = parameter;
        }

        public int Convert(int id)
        {
            switch (Mode)
            {
                case ConvertationMode.Same:
                    return id;
                case ConvertationMode.Removed:
                    return -1;
                case ConvertationMode.Added:
                    return id + Parameter;
                case ConvertationMode.New:
                    return Parameter;
            }
            return -1;
        }
    }

    public struct OneTypeItemIdConvertationRule
    {
        public int OutputItemType;
        public List<Tuple<int, IdConvertationRule>> ConvertationRules;
        public int Priority;
        public int ItemCount { get { return ConvertationRules.Count; } }

        public OneTypeItemIdConvertationRule(int outputItemType, int priority = 1)
        {
            Priority = priority;
            OutputItemType = outputItemType;
            ConvertationRules = new List<Tuple<int, IdConvertationRule>>();
        }
    }
}
