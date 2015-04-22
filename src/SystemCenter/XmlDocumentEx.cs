using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace SystemCenter
{

    public class XmlDocumentEx : XmlDocument
    {
        private string _KEY;

        private byte[] keyBytes;

        private byte[] keyIV;

        private XmlDocumentEx.CryptMode _MODE = XmlDocumentEx.CryptMode.NONE;

        private string _FILENAME = string.Empty;

        public XmlDocumentEx(string psKey)
        {
            this._KEY = psKey;
            this._MODE = XmlDocumentEx.CryptMode.MD5;
            this.CreateKey();
        }

        public XmlDocumentEx(string psKey, XmlDocumentEx.CryptMode psMode)
        {
            this._KEY = psKey;
            this._MODE = psMode;
            this.CreateKey();
        }

        public XmlDocumentEx()
        {
            this._KEY = string.Empty;
            this._MODE = XmlDocumentEx.CryptMode.MD5;
        }

        private bool byteEqual(byte[] src, byte[] tar)
        {
            bool flag = true;
            if ((int)src.Length != (int)tar.Length)
            {
                return false;
            }
            int num = 0;
            while (num < (int)src.Length)
            {
                if (src[num] == tar[num])
                {
                    num++;
                }
                else
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        private void CreateKey()
        {
            switch (this._MODE)
            {
                case XmlDocumentEx.CryptMode.MD5:
                    {
                        HashAlgorithm hashAlgorithm = MD5.Create();
                        byte[] numArray = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(this._KEY));
                        this.keyBytes = new byte[8];
                        this.keyIV = new byte[8];
                        Array.Copy(numArray, 0, this.keyBytes, 0, (int)this.keyBytes.Length);
                        Array.Copy(numArray, 8, this.keyIV, 0, (int)this.keyIV.Length);
                        return;
                    }
                case XmlDocumentEx.CryptMode.CONST8:
                    {
                        this.keyBytes = Encoding.UTF8.GetBytes(this._KEY.Substring(0, 8));
                        this.keyIV = this.keyBytes;
                        return;
                    }
                default:
                    {
                        return;
                    }
            }
        }

        public override void Load(string filename)
        {
            FileStream fileStream = null;
            CryptoStream cryptoStream = null;
            try
            {
                try
                {
                    DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
                    fileStream = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite);
                    switch (this._MODE)
                    {
                        case XmlDocumentEx.CryptMode.MD5:
                            {
                                if (!string.IsNullOrEmpty(this._KEY))
                                {
                                    fileStream.Seek((long)16, SeekOrigin.Current);
                                    goto case XmlDocumentEx.CryptMode.CONST8;
                                }
                                else
                                {
                                    this.keyBytes = new byte[8];
                                    this.keyIV = new byte[8];
                                    fileStream.Read(this.keyBytes, 0, (int)this.keyBytes.Length);
                                    fileStream.Read(this.keyIV, 0, (int)this.keyIV.Length);
                                    goto case XmlDocumentEx.CryptMode.CONST8;
                                }
                            }
                        case XmlDocumentEx.CryptMode.CONST8:
                            {
                                cryptoStream = new CryptoStream(fileStream, dESCryptoServiceProvider.CreateDecryptor(this.keyBytes, this.keyIV), CryptoStreamMode.Read);
                                base.Load(cryptoStream);
                                this._FILENAME = filename;
                                break;
                            }
                        default:
                            {
                                goto case XmlDocumentEx.CryptMode.CONST8;
                            }
                    }
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
                if (cryptoStream != null)
                {
                    cryptoStream.Close();
                }
            }
        }

        public override void Save(string filename)
        {
            FileStream fileStream = null;
            CryptoStream cryptoStream = null;
            try
            {
                try
                {
                    DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
                    fileStream = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite);
                    fileStream.Write(this.keyBytes, 0, (int)this.keyBytes.Length);
                    fileStream.Write(this.keyIV, 0, (int)this.keyIV.Length);
                    cryptoStream = new CryptoStream(fileStream, dESCryptoServiceProvider.CreateEncryptor(this.keyBytes, this.keyIV), CryptoStreamMode.Write);
                    base.Save(cryptoStream);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
                if (cryptoStream != null)
                {
                    cryptoStream.Clear();
                }
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
        }

        public void Save()
        {
            this.Save(this._FILENAME);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            StringWriter stringWriter = new StringWriter(stringBuilder);
            XmlTextWriter xmlTextWriter = null;
            try
            {
                xmlTextWriter = new XmlTextWriter(stringWriter)
                {
                    Formatting = Formatting.Indented,
                    Indentation = 1,
                    IndentChar = '\t'
                };
                base.WriteTo(xmlTextWriter);
            }
            finally
            {
                if (xmlTextWriter != null)
                {
                    xmlTextWriter.Close();
                }
            }
            return stringBuilder.ToString();
        }

        public bool ValidateKey(string psKey)
        {
            return this.ValidateKey(psKey, XmlDocumentEx.CryptMode.MD5);
        }

        public bool ValidateKey(string psKey, XmlDocumentEx.CryptMode psMode)
        {
            byte[] bytes = new byte[8];
            byte[] numArray = new byte[8];
            switch (psMode)
            {
                case XmlDocumentEx.CryptMode.MD5:
                    {
                        HashAlgorithm hashAlgorithm = MD5.Create();
                        byte[] numArray1 = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(psKey));
                        Array.Copy(numArray1, 0, bytes, 0, (int)bytes.Length);
                        Array.Copy(numArray1, 8, numArray, 0, (int)numArray.Length);
                        break;
                    }
                case XmlDocumentEx.CryptMode.CONST8:
                    {
                        bytes = Encoding.UTF8.GetBytes(this._KEY.Substring(0, 8));
                        numArray = this.keyBytes;
                        break;
                    }
            }
            if (!this.byteEqual(bytes, this.keyBytes))
            {
                return false;
            }
            return this.byteEqual(numArray, this.keyIV);
        }

        public enum CryptMode
        {
            MD5,
            CONST8,
            NONE
        }
    }

}
