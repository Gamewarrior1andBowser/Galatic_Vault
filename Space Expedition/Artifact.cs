using System.Net.Security;

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
            Artist = artist;
            Year = year;
            Log = log;

            if (isEncoded == true) {
                IsEncoded = isEncoded;
                EncodedName = name;

            } else {
                string newName = "";
                for (int i = 0; i < name.Length; i++) {
                    newName = newName + Encode(name[i].ToString(), new Random().Next(1, 4));
                }
                EncodedName = newName;
                IsEncoded = true;
            }
        }

        private string Encode(string letter, int level) {
            int charIndex = 0;
            for (int encodingLevel = 0; encodingLevel < level; encodingLevel++) {
                for (int i = 0; i < OriginalArray.Length; i++) {
                    if (OriginalArray[i].ToString() == letter) {
                        charIndex = i;
                        i = OriginalArray.Length;
                    }
                }
                if (encodingLevel == 0) {
                    letter = ReversedArray[charIndex].ToString();
                } else {
                    letter = MappedArray[charIndex].ToString();
                }
            }

            return letter + level.ToString();
        }

        public string Decode(string name) {
            if (IsEncoded == false || name.Length == EncodedName.Length / 2) {
                IsEncoded = false;
                name = name.Replace(" ", "");
                return name;
            } else {
                int nameIndex = 0;
                int charIndex = 0;
                for (int i = 1; i < name.Length; i += 2) {
                    if (name[i].ToString() == "1" || name[i].ToString() == "2" || name[i].ToString() == "3") {
                        nameIndex = i;
                        i = name.Length;
                    } else if (i == name.Length - 1) {
                        IsEncoded = false;
                    }
                }
                if (IsEncoded == true) {
                    string start = name.Substring(0, nameIndex - 1);
                    string insert = "";
                    string end = name.Substring(nameIndex + 1);
                    if (name[nameIndex].ToString() == "3" || name[nameIndex].ToString() == "2") {
                        for (int i = 0; i < MappedArray.Length; i++) {
                            if (MappedArray[i] == name[nameIndex - 1]) {
                                charIndex = i;
                                i = MappedArray.Length;
                            }
                        }
                        int level = name[nameIndex] - 48;
                        insert = OriginalArray[charIndex].ToString() + (level - 1);
                    } else {
                        for (int i = 0; i < OriginalArray.Length; i++) {
                            if (OriginalArray[i] == name[nameIndex - 1]) {
                                charIndex = i;
                                i = OriginalArray.Length;
                            }
                        }
                        if (nameIndex == 1) {
                            insert = ReversedArray[charIndex].ToString() + " ";
                        } else {
                            insert = ReversedArray[charIndex].ToString().ToLower() + " ";
                        }
                    }
                        name = start + insert + end;
                }
                return Decode(name);
            }
        }

        public string Print() {
            if (IsEncoded == true) {
                Name = Decode(EncodedName);
                IsEncoded = false;
            }
            return $"{Name}, {Artist}, {Year}, {Log}";
        }

        public string Save() {
            return $"{EncodedName} | {Artist} | {Year} | {Log}";
        }
    }
}