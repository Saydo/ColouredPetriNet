namespace PetriNet
{
    public class IdGenerator
    {
        private int m_id;

        public IdGenerator(int id = 0)
        {
            m_id = 0;
        }

        public int getNextId()
        {
            return ++m_id;
        }

        public int getCurrId()
        {
            return m_id;
        }

        public void reset(int id = 0)
        {
            m_id = id;
        }
    }
}
