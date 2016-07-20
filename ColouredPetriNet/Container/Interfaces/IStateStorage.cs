using System;
using System.Collections.Generic;
using System.Linq;
namespace ColouredPetriNet.Container.Interfaces
{
    public interface IStateStorage : IPetriNetItemStorage
    {
        IStateWrapper this[int id] { get; }
        IStateWrapper this[int type, int index] { get; }
        StateWrapper<T> GetWrapper<T>(int id);
        StateWrapper<T> GetWrapper<T>(int type, int index);
        Tuple<int, int> Create<T>(T value);
        int Create<T>(int type, T value);
        int Add<T>(int id, T value);
        bool Add<T>(int id, int type, T value);
    }
}
