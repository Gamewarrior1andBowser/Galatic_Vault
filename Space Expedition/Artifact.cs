using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Expedition {
    internal class Artifact {
        public string Name { get; set; }
        public string EncodedName { get; }
        public string Artist { get; }
        public string Year { get; }
        public string Log { get;  }

        public bool IsEncoded { get; set; }

        public Artifact(string name, string artist, string year, string log) {
            EncodedName = name;
            Artist = artist;
            Year = year;
            Log = log;
        }

        public void Decode() {
            if (IsEncoded == false || Name.Length == EncodedName.Length/2) {
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
