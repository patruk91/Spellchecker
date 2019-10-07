namespace Spellchecker
{
    public class KeyValue
    {
        public int key { get; private set; }
        public string value { get; set; }

        public KeyValue(int key, string value)
        {
            this.key = key;
            this.value = value;
        }
    }
}