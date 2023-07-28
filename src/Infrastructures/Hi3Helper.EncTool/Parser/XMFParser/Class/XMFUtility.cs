﻿using Hi3Helper.UABT;
using Hi3Helper.UABT.Binary;
using System;
using System.IO;

namespace Hi3Helper.EncTool.Parser.AssetMetadata
{
    public static class XMFUtility
    {
        /// <summary>
        /// Gets the length of the version that can be received by the XMFParser
        /// </summary>
        public static int XMFVersionLength { get => XMFParser._versioningLength; }

        /// <summary>
        /// Compares the version given from <c>versionBytes</c> with the one from xmfPath.
        /// </summary>
        /// <param name="xmfPath">The path of the XMF file to compare.</param>
        /// <param name="versionBytes">The <c>int</c> array of version to compare. The array length must be 4.</param>
        /// <param name="use4LengthArrayCompare">Use 4 length array compare instead of 3 length array</param>
        /// <returns>
        /// If the version contained in the XMF file matches the one from <c>versionBytes</c> or there's any fault, then return <c>false</c>.<br/>
        /// If it matches, then return <c>true</c>.
        /// </returns>
        public static (bool, int[]) CheckIfXMFVersionMatches(string xmfPath, ReadOnlySpan<int> versionBytes, bool use4LengthArrayCompare = false)
        {
            FileInfo xmf = new FileInfo(xmfPath);

            if (!xmf.Exists || (xmf.Exists && xmf.Length < 0xFF)) return (false, new int[] { });
            if (versionBytes.Length != XMFParser._versioningLength) return (false, new int[] { });

            try
            {
                using (FileStream xmfFS = xmf.OpenRead())
                using (EndianBinaryReader reader = new EndianBinaryReader(xmfFS, EndianType.LittleEndian))
                {
                    reader.Position = XMFParser._signatureLength + 4;
                    ReadOnlySpan<int> versionXMF = XMFParser.ReadVersion(reader);

                    return (versionXMF[0] == versionBytes[0] && versionXMF[1] == versionBytes[1] && versionXMF[2] == versionBytes[2] && (use4LengthArrayCompare ? versionXMF[3] == versionBytes[3] : true),
                            versionXMF.ToArray());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"error while reading XMF file!\r\n{e}");
                return (false, new int[] { });
            }
        }
    }
}
