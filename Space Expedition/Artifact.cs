namespace Space_Expedition {
    internal class Artifact {

        readonly char[] OriginalArray = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        readonly char[] ReversedArray = new char[] { 'Z', 'Y', 'X', 'W', 'V', 'U', 'T', 'S', 'R', 'Q', 'P', 'O', 'N', 'M', 'L', 'K', 'J', 'I', 'H', 'G', 'F', 'E', 'D', 'C', 'B', 'A' };
        readonly char[] MappedArray = new char[] { 'H', 'Z', 'A', 'U', 'Y', 'E', 'K', 'G', 'O', 'T', 'I', 'R', 'J', 'V', 'W', 'N', 'M', 'F', 'Q', 'S', 'D', 'B', 'X', 'L', 'C', 'P' };

        public string Name { get; set; }
        public string EncodedName { get; }
        public string Artist { get; }
        public string Year { get; }
        public string Log { get; }

        public bool IsEncoded { get; set; }

        public Artifact(string name, string artist, string year, string log, bool isEncoded) {
            EncodedName = name;
            Artist = artist;
            Year = year;
            Log = log;

            if (isEncoded == true) {
                IsEncoded = isEncoded;
            } else {
                Encode();
            }
        }

        private void Encode() {

        }

        public void Decode() {
            if (IsEncoded == false || Name.Length == EncodedName.Length / 2) {
                IsEncoded = false;
            } else {

            }
        }

        public string Print() {
            return $"{Name}, {Artist}, {Year}, {Log}";
        }

        public string Save() {
            return $"{EncodedName} | {Artist} | {Year} | {Log}";
        }
    }
}