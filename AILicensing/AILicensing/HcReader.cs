#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Numerics;
using System.IO;

#endregion

namespace AILicensing {

    public class HcReader {

        #region Fields

        private string code;
        private string version;
        private char[] sepK;
        private char[] sepD;
        private string fileName;
        private byte[] M;
        private byte[] D;
        private byte[] E;

        #endregion

        #region Constructor

        public HcReader() {
            sepK = new char[] { ' ' };
            sepD = new char[] { '-' };

            code = "AILogSys";
            version = "1.0";
            fileName = "AILicKey.txt";
            M = new byte[] { 2, 3, 4 };
            D = new byte[] { 2, 3, 4 };
            E = new byte[] { 2, 3, 4 };
        }

        //for testing
        public HcReader(string code, string version, string fileName, string pkFileName) {
            sepK = new char[] { ' ' };
            sepD = new char[] { '-' };

            this.code = code;
            this.version = version;
            this.fileName = fileName;
            GetMDEFromPkFile(pkFileName);
        }

        #endregion

        #region Public Methods

        public bool Process(string fileName, RSAGen rsaGen) {
            byte[] encData = GetEncData(fileName);
            RSAParameters key = new RSAParameters(); key.Modulus = M; key.D = D; key.Exponent = E;
            string txtKey = Decode(encData, key);
            return ProcessKey(txtKey);
        }

        #endregion

        #region Private Methods

        private void SetRSAParams(RSAParameters rsaParams) {
            M = rsaParams.Modulus;
            D = rsaParams.D;
            E = rsaParams.Exponent;
        }
        
        private byte[] GetEncData(string fileName) {
            List<byte> bytes = new List<byte>();
            try {
                StreamReader sr = new StreamReader(fileName);
                string line;
                while ((line = sr.ReadLine()) != null) { bytes.AddRange(ToByteArray(line)); }
                return bytes.ToArray();
            }
            catch {
                return null;
            }
        }

        private string Decode(byte[] encData, RSAParameters privKey) {
            byte[] decBytes = DecryptPrivate(encData, privKey);
            byte[] decData = decBytes.SkipWhile(x => x != 0).Skip(1).ToArray();
            return ToString(decData);
        }

        private byte[] DecryptPrivate(byte[] data, RSAParameters key) {
            Params pars = GetParams(key);
            return Calculate(data, pars.privExponent, pars.modulus);
        }

        private Params GetParams(RSAParameters key) {
            Params rsap = new Params();
            rsap.modulus = new BigInteger(key.Modulus.Reverse().Concat(new byte[] { 0 }).ToArray());
            rsap.privExponent = new BigInteger(key.D.Reverse().Concat(new byte[] { 0 }).ToArray());
            rsap.pubExponent = new BigInteger(key.Exponent.Reverse().Concat(new byte[] { 0 }).ToArray());
            return rsap;
        }

        private static byte[] Calculate(byte[] data, BigInteger exp, BigInteger mod) {
            BigInteger bigData = new BigInteger(data.Reverse().Concat(new byte[] { 0 }).ToArray());
            return BigInteger.ModPow(bigData, exp, mod).ToByteArray().Reverse().ToArray();
        }

        public struct Params {
            public BigInteger modulus;
            public BigInteger privExponent;
            public BigInteger pubExponent;
        }

        private string ToString(byte[] bytes) {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes) { sb.Append(Convert.ToChar(b)); }
            return sb.ToString();
        }

        private byte[] ToByteArray(string str) {
            string[] tokens = str.Split(sepK);
            byte[] res = new byte[tokens.Length-1];
            for (int i = 0; i < tokens.Length-1; i++) { res[i] = Convert.ToByte(tokens[i]); }
            return res;
        }

        private bool ProcessKey(string key) {
            string[] kTokens = key.Split(sepK);
            if (kTokens.Length != 3) { return false; }
            if (kTokens[0] != code) { return false; }
            if (kTokens[1] != version) { return false; }
            string[] dTokens = kTokens[2].Split(sepD);
            if (dTokens.Length != 3) { return false; }
            DateTime end = DateTime.MaxValue;
            try { end = new DateTime(Convert.ToInt32(dTokens[0]), Convert.ToInt32(dTokens[1]), Convert.ToInt32(dTokens[2])); }
            catch { }
            if (end.Date < DateTime.Now.Date) { return false; }
            return true;
        }

        private void GetMDEFromPkFile(string pkFileName) {
            char[] sep = new char[] { ' ' };
            string[] tokens;
            try {
                StreamReader sr = new StreamReader(pkFileName);
                string line;
                line = sr.ReadLine();  //PRIVATE KEY
                line = sr.ReadLine();  //
                line = sr.ReadLine();  //M:
                line = sr.ReadLine();  //M array
                tokens = line.Split(sep);
                M = new byte[tokens.Length-1];
                for(int i=0;i<tokens.Length-1;i++) { M[i] = Convert.ToByte(tokens[i]); }
                line = sr.ReadLine();  //D:
                line = sr.ReadLine();  //D array
                tokens = line.Split(sep);
                D = new byte[tokens.Length-1];
                for(int i=0;i<tokens.Length-1;i++) { D[i] = Convert.ToByte(tokens[i]); }
                line = sr.ReadLine();  //E:
                line = sr.ReadLine();  //E array
                tokens = line.Split(sep);
                E = new byte[tokens.Length-1];
                for (int i = 0; i < tokens.Length-1; i++) { E[i] = Convert.ToByte(tokens[i]); }
            }
            catch {
                Console.WriteLine("Error");
            }
        }

        #endregion

    }
}
