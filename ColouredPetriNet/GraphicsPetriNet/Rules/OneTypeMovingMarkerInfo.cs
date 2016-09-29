using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColouredPetriNet.GraphicsPetriNet.Rules
{
    public enum MoveIdConvertType { Move, Delete };

    public class OneTypeMovingMarkerInfo
    {
        public const int All = -1;

        public int MarkerType { get; private set; }
        public MoveIdConvertType CommonConvertType { get; private set; }
        public int Count { get; private set; }
        public List<MoveIdConvertType> IdConvertList;

        public OneTypeMovingMarkerInfo()
            : this(-1, MoveIdConvertType.Move, -1)
        {
        }

        public OneTypeMovingMarkerInfo(int markerType, MoveIdConvertType convertType, int count)
        {
            MarkerType = markerType;
            CommonConvertType = convertType;
            Count = count;
            IdConvertList = new List<MoveIdConvertType>();
        }
    }
}
