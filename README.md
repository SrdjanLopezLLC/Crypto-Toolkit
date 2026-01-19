# Decrypter By SL LLC

A Windows Forms cryptography toolkit for decryption, signature verification, and file hashing.

## Features

**Decryption**
- AES (128/192/256-bit, CBC or ECB mode)
- DES
- TripleDES
- RC2
- Rijndael
- RSA (OAEP padding)

**Signature Verification**
- DSA
- ECDsa (NIST P-256)

**File Hashing**
- MD5
- SHA1
- SHA256
- SHA384
- SHA512

**Key Exchange**
- ECDH (Elliptic Curve Diffie-Hellman) with AES encryption

## Requirements

- Windows 10 or later
- .NET Framework 4.8
- BouncyCastle (NuGet package, restores automatically)

## Installation

1. Clone the repository
```
git clone https://github.com/PradaFit/Crypto-Toolkit.git
```
2. Open `Decrypter By SL LLC.sln` in Visual Studio
3. Build the solution (Ctrl+Shift+B)
4. Run the application (F5)

NuGet will automatically restore the BouncyCastle dependency on first build.

## Usage

### Main Window Controls

| Control | Purpose |
|---------|---------|
| Algorithm Dropdown | Select the cryptographic algorithm |
| Main Textbox | Input field for ciphertext, signature, or data |
| Key Textbox | Enter your decryption key (Base64 encoded) |
| IV Textbox | Enter the initialization vector (Base64 encoded) |
| Mode Dropdown | Select CBC or ECB for block ciphers |
| Output Format | Choose UTF-8, Decimal, or Binary output |
| Output Textbox | Displays the result |

---

### Decrypting with AES

AES supports 128, 192, and 256-bit keys. All inputs must be Base64 encoded.

1. Select `AES` from the algorithm dropdown
2. Paste your Base64-encoded ciphertext in the main textbox
3. Enter your Base64-encoded key in the key field
   - 16 bytes for AES-128
   - 24 bytes for AES-192
   - 32 bytes for AES-256
4. Select cipher mode:
   - `CBC` requires a 16-byte IV (Base64 encoded)
   - `ECB` does not require an IV
5. Enter the IV if using CBC mode
6. Choose your output format
7. Click `Decrypt`

Example inputs:
```
Ciphertext: U2FsdGVkX1+... (your Base64 ciphertext)
Key: YWJjZGVmZ2hpamtsbW5vcA== (16 bytes = 128-bit key)
IV: MDEyMzQ1Njc4OTAxMjM0NQ== (16 bytes)
```

---

### Decrypting with DES / TripleDES / RC2 / Rijndael

These algorithms follow the same pattern as AES:

1. Select the algorithm from the dropdown
2. Paste Base64-encoded ciphertext
3. Enter Base64-encoded key
   - DES: 8 bytes
   - TripleDES: 16 or 24 bytes
   - RC2: 5-16 bytes
   - Rijndael: 16, 24, or 32 bytes
4. Enter Base64-encoded IV
5. Click `Decrypt`

---

### Decrypting with RSA

RSA decryption uses OAEP padding and requires a PEM-formatted private key.

1. Select `RSA` from the dropdown
2. Paste your Base64-encoded ciphertext in the main textbox
3. Paste your full PEM private key in the key field, including the headers:
```
-----BEGIN RSA PRIVATE KEY-----
MIIEpAIBAAKCAQEA...
-----END RSA PRIVATE KEY-----
```
4. Click `Decrypt`

Note: RSA can only decrypt data that was encrypted with the corresponding public key.

---

### Verifying Signatures (DSA / ECDsa)

Use this to verify that data was signed by the holder of a private key.

1. Select `DSA` or `ECDsa` from the dropdown
2. Paste the Base64-encoded signature in the main textbox
3. Paste the PEM public key in the key field
4. Enter the Base64-encoded original data in the IV field
5. Click `Verify`

Result will show "Signature Verified" or "Signature Invalid"

---

### Hashing a File

Generate a hash of any file to verify its integrity.

1. Select a hash algorithm from the dropdown:
   - `MD5` (128-bit, fast but not secure)
   - `SHA1` (160-bit, deprecated for security)
   - `SHA256` (256-bit, recommended)
   - `SHA384` (384-bit)
   - `SHA512` (512-bit)
2. Click `Browse` and select your file
3. Click `Verify SHA`
4. The hash appears in the output box as a lowercase hex string

Example SHA256 output:
```
e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855
```

You can compare this hash against a known value to verify the file has not been modified.

---

### ECDH Key Exchange (Form2)

Elliptic Curve Diffie-Hellman allows two parties to derive a shared secret over an insecure channel.

**Step 1: Generate Your Key Pair**
1. Open Form2 by clicking the appropriate button
2. Click `Generate Key Pair`
3. Your public key appears in the first textbox
4. Send this public key to the other party

**Step 2: Import Peer's Public Key**
1. Click `Browse` to load their public key from a file, or paste it directly
2. Their key appears in the second textbox

**Step 3: Perform Key Exchange**
1. Click `Key Exchange`
2. The shared secret is derived and displayed
3. An AES key is generated from the shared secret using SHA256

**Step 4: Encrypt/Decrypt Messages**
1. Type your message in the message field
2. Click `Encrypt` to encrypt using the derived AES key
3. Send the encrypted message to the other party
4. They can decrypt it using their derived key (which will be identical)

Both parties end up with the same AES key without ever transmitting it directly.

---

## Output Formats

| Format | Description |
|--------|-------------|
| UTF-8 | Standard text encoding, use for readable plaintext |
| Decimal | Space-separated byte values (0-255) |
| Binary | Space-separated 8-bit binary strings |

---

## Troubleshooting

**"Key must be 128, 192, or 256 bits"**
- Your AES key is the wrong length. Make sure it is exactly 16, 24, or 32 bytes before Base64 encoding.

**"CBC mode needs an IV"**
- You selected CBC mode but did not provide an IV. Either provide a 16-byte Base64-encoded IV or switch to ECB mode.

**"IV must be 16 bytes"**
- Your IV is the wrong length. AES requires exactly 16 bytes.

**"Select a file first"**
- Click Browse and select a file before clicking Verify SHA.

**Decryption produces garbage text**
- Wrong key, IV, or algorithm
- Wrong cipher mode (CBC vs ECB)
- Data was not encrypted with the algorithm you selected

---

## Build From Source

1. Install Visual Studio 2019 or later with .NET desktop development workload
2. Clone the repository
3. Open `Decrypter By SL LLC.sln`
4. Build > Build Solution (or Ctrl+Shift+B)
5. The executable will be in `bin/Debug/` or `bin/Release/`

---

## License

This project is provided as-is for educational and personal use.

## Author

PradaFit - [GitHub](https://github.com/PradaFit) - [LinkedIn](https://www.linkedin.com/in/srdjanlopez/)

