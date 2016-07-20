using System.Collections;
using System.Collections.Generic;

namespace ColouredPetriNet.Container
{
    public interface IOneTypeItemList
    {
        int Type { get; }
        IList Items { get; }
    }

    public class OneTypeItemList<T> : IOneTypeItemList
    {
        public int Type { get; private set; }
        public IList Items { get; private set; }

        public OneTypeItemList(int type) : this(type, new List<T>())
        {
        }

        public OneTypeItemList(int type, List<T> itemList)
        {
            Type = type;
            Items = itemList;
        }
    }
}
