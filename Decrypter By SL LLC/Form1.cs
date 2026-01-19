using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Decrypter_By_SL_LLC
{
    public partial class Decrypter : Form
    {
        private string selectedFilePath;

        public Decrypter()
        {
            InitializeComponent();
        }

        private void Decrypter_Load(object sender, EventArgs e)
        {
            // Symmetric
            cmbAlg.Items.Add("AES");
            cmbAlg.Items.Add("DES");
            cmbAlg.Items.Add("TripleDES");
            cmbAlg.Items.Add("RC2");
            cmbAlg.Items.Add("Rijndael");

            // Asymmetric
            cmbAlg.Items.Add("RSA");
            cmbAlg.Items.Add("DSA");
            cmbAlg.Items.Add("ECDsa");
            cmbAlg.Items.Add("ECDiffieHellman");

            // Hashing
            cmbAlg.Items.Add("MD5");
            cmbAlg.Items.Add("SHA1");
            cmbAlg.Items.Add("SHA256");
            cmbAlg.Items.Add("SHA384");
            cmbAlg.Items.Add("SHA512");

            cmbEncMode.Items.Add("CBC");
            cmbEncMode.Items.Add("ECB");

            cmbOutputFormat.Items.Add("UTF-8");
            cmbOutputFormat.Items.Add("Decimal");
            cmbOutputFormat.Items.Add("Binary");

            cmbAlg.SelectedIndex = 0;
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string alg = cmbAlg.SelectedItem?.ToString() ?? "";
            string key = txtKey.Text;
            string iv = txtIVInput.Text;
            string input = txtMain.Text;
            string fmt = cmbOutputFormat.SelectedItem?.ToString() ?? "UTF-8";

            try
            {
                byte[] resultBytes = null;
                string resultText = null;

                switch (alg)
                {
                    case "AES":
                        resultBytes = DecryptAes(input, key, iv);
                        break;
                    case "DES":
                        resultText = DecryptDes(input, key, iv);
                        break;
                    case "TripleDES":
                        resultText = DecryptTripleDes(input, key, iv);
                        break;
                    case "RSA":
                        resultText = DecryptRsa(input, key);
                        break;
                    case "RC2":
                        resultText = DecryptRc2(input, key, iv);
                        break;
                    case "Rijndael":
                        resultText = DecryptRijndael(input, key, iv);
                        break;
                    default:
                        txtOutput.Text = "Pick a decryption algorithm.";
                        return;
                }

                if (resultBytes != null)
                    txtOutput.Text = FormatOutput(resultBytes, fmt);
                else if (!string.IsNullOrEmpty(resultText))
                    txtOutput.Text = FormatOutput(Encoding.UTF8.GetBytes(resultText), fmt);
                else
                    txtOutput.Text = "Decryption failed.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bruh: " + ex.Message);
            }
        }

        private string FormatOutput(byte[] data, string fmt)
        {
            switch (fmt)
            {
                case "Decimal":
                    return string.Join(" ", data.Select(b => b.ToString()));
                case "Binary":
                    return string.Join(" ", data.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')));
                default:
                    return Encoding.UTF8.GetString(data);
            }
        }

        private byte[] DecryptAes(string input, string key, string iv)
        {
            byte[] keyBytes = Convert.FromBase64String(key);
            if (keyBytes.Length != 16 && keyBytes.Length != 24 && keyBytes.Length != 32)
                throw new ArgumentException("Key must be 128, 192, or 256 bits.");

            string modeStr = cmbEncMode.SelectedItem?.ToString();
            CipherMode mode;
            if (string.Equals(modeStr, "ECB", StringComparison.OrdinalIgnoreCase))
                mode = CipherMode.ECB;
            else if (string.Equals(modeStr, "CBC", StringComparison.OrdinalIgnoreCase))
                mode = CipherMode.CBC;
            else
                mode = string.IsNullOrEmpty(iv) ? CipherMode.ECB : CipherMode.CBC;

            byte[] ivBytes;
            if (mode == CipherMode.CBC)
            {
                if (string.IsNullOrEmpty(iv))
                    throw new ArgumentException("CBC mode needs an IV.");
                ivBytes = Convert.FromBase64String(iv);
                if (ivBytes.Length != 16)
                    throw new ArgumentException("IV must be 16 bytes.");
            }
            else
            {
                ivBytes = new byte[16];
            }

            byte[] cipher = Convert.FromBase64String(input);

            using (var aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = ivBytes;
                aes.Mode = mode;
                aes.Padding = PaddingMode.PKCS7;

                using (var ms = new MemoryStream(cipher))
                using (var dec = aes.CreateDecryptor())
                using (var cs = new CryptoStream(ms, dec, CryptoStreamMode.Read))
                using (var output = new MemoryStream())
                {
                    cs.CopyTo(output);
                    return output.ToArray();
                }
            }
        }

        private string DecryptDes(string input, string key, string iv)
        {
            byte[] cipher = Convert.FromBase64String(input);
            byte[] keyBytes = Convert.FromBase64String(key);
            byte[] ivBytes = Convert.FromBase64String(iv);

            using (var des = DES.Create())
            {
                des.Key = keyBytes;
                des.IV = ivBytes;
                using (var ms = new MemoryStream(cipher))
                using (var dec = des.CreateDecryptor())
                using (var cs = new CryptoStream(ms, dec, CryptoStreamMode.Read))
                using (var sr = new StreamReader(cs))
                    return sr.ReadToEnd();
            }
        }

        private string DecryptTripleDes(string input, string key, string iv)
        {
            byte[] cipher = Convert.FromBase64String(input);
            byte[] keyBytes = Convert.FromBase64String(key);
            byte[] ivBytes = Convert.FromBase64String(iv);

            using (var tdes = TripleDES.Create())
            {
                tdes.Key = keyBytes;
                tdes.IV = ivBytes;
                using (var ms = new MemoryStream(cipher))
                using (var dec = tdes.CreateDecryptor())
                using (var cs = new CryptoStream(ms, dec, CryptoStreamMode.Read))
                using (var sr = new StreamReader(cs))
                    return sr.ReadToEnd();
            }
        }

        private string DecryptRsa(string input, string privateKeyPem)
        {
            byte[] cipher = Convert.FromBase64String(input);
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(ParseRsaPrivateKey(privateKeyPem));
                byte[] plain = rsa.Decrypt(cipher, true); // OAEP
                return Encoding.UTF8.GetString(plain);
            }
        }

        private RSAParameters ParseRsaPrivateKey(string pem)
        {
            using (var reader = new StringReader(pem))
            {
                var pemReader = new PemReader(reader);
                var keyPair = (AsymmetricCipherKeyPair)pemReader.ReadObject();
                var priv = (RsaPrivateCrtKeyParameters)keyPair.Private;
                return DotNetUtilities.ToRSAParameters(priv);
            }
        }

        private string DecryptRc2(string input, string key, string iv)
        {
            byte[] cipher = Convert.FromBase64String(input);
            byte[] keyBytes = Convert.FromBase64String(key);
            byte[] ivBytes = Convert.FromBase64String(iv);

            using (var rc2 = RC2.Create())
            {
                rc2.Key = keyBytes;
                rc2.IV = ivBytes;
                using (var ms = new MemoryStream(cipher))
                using (var dec = rc2.CreateDecryptor())
                using (var cs = new CryptoStream(ms, dec, CryptoStreamMode.Read))
                using (var sr = new StreamReader(cs))
                    return sr.ReadToEnd();
            }
        }

        private string DecryptRijndael(string input, string key, string iv)
        {
            byte[] cipher = Convert.FromBase64String(input);
            byte[] keyBytes = Convert.FromBase64String(key);
            byte[] ivBytes = Convert.FromBase64String(iv);

            using (var rij = Rijndael.Create())
            {
                rij.Key = keyBytes;
                rij.IV = ivBytes;
                using (var ms = new MemoryStream(cipher))
                using (var dec = rij.CreateDecryptor())
                using (var cs = new CryptoStream(ms, dec, CryptoStreamMode.Read))
                using (var sr = new StreamReader(cs))
                    return sr.ReadToEnd();
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e) { }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            string alg = cmbAlg.SelectedItem?.ToString() ?? "";
            string pubKey = txtKey.Text;
            string sig = txtMain.Text;
            string data = txtIVInput.Text;

            try
            {
                byte[] dataBytes = Convert.FromBase64String(data);
                byte[] sigBytes = Convert.FromBase64String(sig);
                bool ok = false;

                switch (alg)
                {
                    case "DSA":
                        ok = VerifyDsa(dataBytes, sigBytes, pubKey);
                        break;
                    case "ECDsa":
                        var ecParams = ParseEcPublicKey(pubKey);
                        using (var ecdsa = ECDsa.Create(ecParams))
                            ok = ecdsa.VerifyData(dataBytes, sigBytes, HashAlgorithmName.SHA256);
                        break;
                }

                txtOutput.Text = ok ? "Signature Verified" : "Signature Invalid";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bruh: " + ex.Message);
            }
        }

        private bool VerifyDsa(byte[] data, byte[] sig, string pubKeyPem)
        {
            using (var reader = new StringReader(pubKeyPem))
            {
                var pr = new PemReader(reader);
                var dsaKey = (DsaPublicKeyParameters)pr.ReadObject();
                var dsaParams = new DSAParameters
                {
                    G = dsaKey.Parameters.G.ToByteArrayUnsigned(),
                    P = dsaKey.Parameters.P.ToByteArrayUnsigned(),
                    Q = dsaKey.Parameters.Q.ToByteArrayUnsigned(),
                    Y = dsaKey.Y.ToByteArrayUnsigned()
                };

                using (var dsa = new DSACryptoServiceProvider())
                {
                    dsa.ImportParameters(dsaParams);
                    return dsa.VerifyData(data, sig, HashAlgorithmName.SHA1);
                }
            }
        }

        private ECParameters ParseEcPublicKey(string pem)
        {
            using (var reader = new StringReader(pem))
            {
                var pr = new PemReader(reader);
                var ecKey = (ECPublicKeyParameters)pr.ReadObject();
                return new ECParameters
                {
                    Curve = ECCurve.NamedCurves.nistP256,
                    Q = new ECPoint
                    {
                        X = ecKey.Q.AffineXCoord.GetEncoded(),
                        Y = ecKey.Q.AffineYCoord.GetEncoded()
                    }
                };
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = ofd.FileName;
                    txtMain.Text = "Got it. Let's go!";
                }
            }
        }

        private void btnVerifySha_Click(object sender, EventArgs e)
        {
            string alg = cmbAlg.SelectedItem?.ToString() ?? "";

            if (string.IsNullOrEmpty(selectedFilePath) || !File.Exists(selectedFilePath))
            {
                MessageBox.Show("Select a file first.");
                return;
            }

            try
            {
                string hash;
                using (var stream = File.OpenRead(selectedFilePath))
                {
                    HashAlgorithm hasher = null;
                    try
                    {
                        switch (alg)
                        {
                            case "MD5": hasher = MD5.Create(); break;
                            case "SHA1": hasher = SHA1.Create(); break;
                            case "SHA256": hasher = SHA256.Create(); break;
                            case "SHA384": hasher = SHA384.Create(); break;
                            case "SHA512": hasher = SHA512.Create(); break;
                            default:
                                MessageBox.Show("Pick a hash algorithm.");
                                return;
                        }
                        byte[] hashBytes = hasher.ComputeHash(stream);
                        var sb = new StringBuilder();
                        foreach (byte b in hashBytes)
                            sb.Append(b.ToString("x2"));
                        hash = sb.ToString();
                    }
                    finally
                    {
                        hasher?.Dispose();
                    }
                }
                txtOutput.Text = hash;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnNewForm_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }

        private void btnClearMain_Click(object sender, EventArgs e)
        {
            txtMain.Text = "";
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            txtMain.Text = "";
            txtOutput.Text = "";
            txtKey.Text = "";
            txtIVInput.Text = "";
            cmbAlg.SelectedIndex = -1;
            cmbEncMode.SelectedIndex = -1;
            cmbOutputFormat.SelectedIndex = -1;
            selectedFilePath = null;
        }

        private void imgArrow_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/PradaFit";
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch { }
            MessageBox.Show("Made By PradaFit");
        }

        // Designer event stubs
        private void txtMain_TextChanged(object sender, EventArgs e) { }
        private void txtOutput_TextChanged(object sender, EventArgs e) { }
        private void txtKey_TextChanged(object sender, EventArgs e) { }
        private void txtIVInput_TextChanged(object sender, EventArgs e) { }
        private void cmbAlg_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbEncMode_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
