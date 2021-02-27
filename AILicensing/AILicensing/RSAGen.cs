#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Security.Cryptography;
using System.IO;

#endregion

namespace AILicensing {

    public class RSAGen {

        #region Fields

        private RSACryptoServiceProvider csp;
        private RSAParameters privateKey;
        private RSAParameters publicKey;
        private string code;
        private string version;
        private string fileName;

        #endregion

        #region Constructor

        public RSAGen() {
            code = "AILogSys";
            version = "1.0";
            fileName = @"..\..\..\Files\AILicKey";
        }

        #endregion

        #region Properties

        public RSAParameters PrivateKey {
            get { return privateKey; }
        }

        public RSAParameters PublicKey {
            get { return publicKey; }
        }

        #endregion

        #region Public Methods

        #region Licence Methods

        public void GeneratePrivKeyFile(string version) {
            csp = new RSACryptoServiceProvider();
            publicKey = csp.ExportParameters(false);
            privateKey = csp.ExportParameters(true);
      
            this.version = version;
            string pkFileName = @"..\..\..\Files\PK" + version + ".txt";
            StreamWriter swPrivKey = new StreamWriter(pkFileName);
            swPrivKey.WriteLine("PRIVATE KEY");
            swPrivKey.WriteLine("");
            swPrivKey.WriteLine("M:");
            for (int i = 0; i < privateKey.Modulus.Length; i++) { swPrivKey.Write(privateKey.Modulus[i] + " "); }
            swPrivKey.WriteLine("");
            swPrivKey.WriteLine("D:");
            for (int i = 0; i < privateKey.D.Length; i++) { swPrivKey.Write(privateKey.D[i] + " "); }
            swPrivKey.WriteLine("");
            swPrivKey.WriteLine("E:");
            for (int i = 0; i < privateKey.Exponent.Length; i++) { swPrivKey.Write(privateKey.Exponent[i] + " "); }
            swPrivKey.WriteLine("");
            swPrivKey.Close();
        }

        public void GenerateLicFile(string n, DateTime end) {
            string key = code + " " + version + " " + end.Year + "-" + end.Month + "-" + end.Day;
            StreamWriter sw = new StreamWriter(fileName + n + ".txt");
            byte[] encData = Code(key);
            foreach (byte b in encData) { sw.Write(b + " "); }
            sw.Close();
        }

        #endregion

        #region General Methods

        public byte[] Code(string dataStr) {
            byte[] data = ToByteArray(dataStr);
            byte[] encData = csp.Encrypt(data, false);
            return encData;
        }

        public string Decode(byte[] encData, RSAParameters privKey) {
            byte[] decBytes = DecryptPrivate(encData, privKey);
            byte[] decData = decBytes.SkipWhile(x => x != 0).Skip(1).ToArray();
            return ToString(decData);
        }

        public string Decode(byte[] encData) {
            byte[] M = { 2, 3, 4 };
            byte[] D = { 2, 3, 4 };
            byte[] E = { 2, 3, 4 };

            RSAParameters rsaParams = new RSAParameters();
            rsaParams.Modulus = M;
            rsaParams.D = D;
            rsaParams.Exponent = E;

            return Decode(encData, rsaParams);
        }

        #endregion

        #endregion

        #region Private Methods

        #region Main Methods

        public byte[] EncryptPrivate(byte[] data, RSAParameters key) {
            Params pars = GetParams(key);
            return Calculate(data, pars.privExponent, pars.modulus);
        }

        public byte[] EncryptPublic(byte[] data, RSAParameters key) {
            Params pars = GetParams(key);
            return Calculate(data, pars.pubExponent, pars.modulus);
        }

        public byte[] DecryptPrivate(byte[] data, RSAParameters key) {
            Params pars = GetParams(key);
            return Calculate(data, pars.privExponent, pars.modulus);
        }

        public byte[] DecryptPublic(byte[] data, RSAParameters key) {
            Params pars = GetParams(key);
            return Calculate(data, pars.pubExponent, pars.modulus);
        }

        #endregion

        #region Auxiliar Methods

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
            //data : our data block, Reverse(): as BigInteger has another order, append 0 only positive numbers, should be array
            //ModPow: the RSA operation itself, bytes from BigInteger, back to original order, return as byte array
        }

        #endregion

        #endregion

        #region Text methods

        private byte[] ToByteArray(string text) {
            char[] textChar = text.ToCharArray();
            byte[] res = new byte[textChar.Length];
            for (int i = 0; i < textChar.Length; i++) { res[i] = Convert.ToByte(textChar[i]); }
            return res;
        }

        private string ToString(byte[] bytes) {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes) { sb.Append(Convert.ToChar(b)); }
            return sb.ToString();
        }

        #endregion

        #region Inner struct

        public struct Params {
            public BigInteger modulus;
            public BigInteger privExponent;
            public BigInteger pubExponent;
        }

        #endregion
    }
}
