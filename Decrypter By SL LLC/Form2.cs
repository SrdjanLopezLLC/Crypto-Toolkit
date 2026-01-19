using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Decrypter_By_SL_LLC
{
    public partial class Form2 : Form
    {
        private ECDiffieHellmanCng _ecdh;
        private byte[] _sharedSecret;
        private byte[] _aesKey;

        public Form2()
        {
            InitializeComponent();
            btnEncrypt.Click += btnGenerateKeyPair_Click;
            btnBrowse.Click += btnImportPeerKey_Click;
            button1.Click += btnKeyExchange_Click;
            button2.Click += btnEncryptMsg_Click;
            button3.Click += btnDecryptMsg_Click;
        }

        private void btnGenerateKeyPair_Click(object sender, EventArgs e)
        {
            try
            {
                _ecdh?.Dispose();
                _ecdh = new ECDiffieHellmanCng(256)
                {
                    KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash,
                    HashAlgorithm = CngAlgorithm.Sha256
                };

                byte[] pubKey = _ecdh.PublicKey.ToByteArray();
                richTextBox1.Text = Convert.ToBase64String(pubKey);
                txtOutput.Text = "Key pair ready.";
            }
            catch (CryptographicException ex)
            {
                txtOutput.Text = "Crypto error: " + ex.Message;
            }
        }

        private void btnImportPeerKey_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog { Filter = "All files|*.*" })
            {
                if (ofd.ShowDialog() != DialogResult.OK) return;
                try
                {
                    richTextBox2.Text = File.ReadAllText(ofd.FileName).Trim();
                    txtOutput.Text = "Peer key loaded.";
                }
                catch (IOException ex)
                {
                    txtOutput.Text = "File error: " + ex.Message;
                }
            }
        }

        private void btnKeyExchange_Click(object sender, EventArgs e)
        {
            if (_ecdh == null)
            {
                txtOutput.Text = "Generate your keys first.";
                return;
            }
            if (string.IsNullOrWhiteSpace(richTextBox2.Text))
            {
                txtOutput.Text = "Need peer's public key.";
                return;
            }

            try
            {
                byte[] peerBytes = Convert.FromBase64String(richTextBox2.Text.Trim());
                using (var peerKey = ECDiffieHellmanCngPublicKey.FromByteArray(peerBytes, CngKeyBlobFormat.EccPublicBlob))
                {
                    _sharedSecret = _ecdh.DeriveKeyMaterial(peerKey);
                }
                richTextBox3.Text = Convert.ToBase64String(_sharedSecret);

                using (var sha = SHA256.Create())
                {
                    _aesKey = sha.ComputeHash(_sharedSecret);
                }
                richTextBox4.Text = Convert.ToBase64String(_aesKey);
                txtOutput.Text = "Exchange done.";
            }
            catch (Exception ex)
            {
                txtOutput.Text = ex.Message;
            }
        }

        private void btnEncryptMsg_Click(object sender, EventArgs e)
        {
            if (_aesKey == null)
            {
                txtOutput.Text = "Do key exchange first.";
                return;
            }
            string msg = richTextBox5.Text;
            if (string.IsNullOrEmpty(msg))
            {
                txtOutput.Text = "Type something to encrypt.";
                return;
            }

            try
            {
                byte[] iv = new byte[16];
                using (var rng = new RNGCryptoServiceProvider()) rng.GetBytes(iv);

                byte[] cipher;
                using (var aes = Aes.Create())
                {
                    aes.Key = _aesKey;
                    aes.IV = iv;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    using (var enc = aes.CreateEncryptor())
                    {
                        byte[] plain = Encoding.UTF8.GetBytes(msg);
                        cipher = enc.TransformFinalBlock(plain, 0, plain.Length);
                    }
                }

                string result = Convert.ToBase64String(iv) + "." + Convert.ToBase64String(cipher);
                richTextBox7.Text = result;
                richTextBox6.Text = result;
                txtOutput.Text = "Encrypted.";
            }
            catch (CryptographicException ex)
            {
                txtOutput.Text = "Encrypt failed: " + ex.Message;
            }
        }

        private void btnDecryptMsg_Click(object sender, EventArgs e)
        {
            if (_aesKey == null)
            {
                txtOutput.Text = "Do key exchange first.";
                return;
            }
            string input = richTextBox6.Text.Trim();
            if (string.IsNullOrEmpty(input))
            {
                txtOutput.Text = "Paste encrypted text.";
                return;
            }

            string[] parts = input.Split('.');
            if (parts.Length != 2)
            {
                txtOutput.Text = "Bad format. Expected: IV.CipherText";
                return;
            }

            try
            {
                byte[] iv = Convert.FromBase64String(parts[0]);
                byte[] cipher = Convert.FromBase64String(parts[1]);

                using (var aes = Aes.Create())
                {
                    aes.Key = _aesKey;
                    aes.IV = iv;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    using (var dec = aes.CreateDecryptor())
                    {
                        byte[] plain = dec.TransformFinalBlock(cipher, 0, cipher.Length);
                        richTextBox8.Text = Encoding.UTF8.GetString(plain);
                    }
                }
                txtOutput.Text = "Decrypted.";
            }
            catch (CryptographicException ex)
            {
                txtOutput.Text = "Decrypt failed: " + ex.Message;
            }
            catch (FormatException)
            {
                txtOutput.Text = "Invalid base64.";
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _ecdh?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
