using System.Net.Security;

namespace Space_Expedition {
    internal class Artifact {
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

                Decode();
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