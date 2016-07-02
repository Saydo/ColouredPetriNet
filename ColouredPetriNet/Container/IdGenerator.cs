namespace ColouredPetriNet.Container
{
    public class IdGenerator
    {
        private int _id;

        public IdGenerator(int id = 0)
        {
            _id = 0;
        }

        public int GetNextId()
        {
            return ++_id;
        }

        public int GetCurrId()
        {
            return _id;
        }

        public void Reset(int id = 0)
        {
            _id = id;
        }
    }
}
