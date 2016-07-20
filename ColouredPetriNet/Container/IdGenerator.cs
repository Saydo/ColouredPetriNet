namespace ColouredPetriNet.Container
{
    public class IdGenerator
    {
        private int _id;
        public int CurrentId { get { return _id; } }

        public IdGenerator(int id = 0)
        {
            _id = 0;
        }

        public int Next()
        {
            return ++_id;
        }

        public void Reset(int id = 0)
        {
            _id = id;
        }
    }
}
