﻿namespace Hi3Helper.SharpHDiffPatch
{
    public interface IPatch
    {
        void Patch(string input, string output, bool useBufferedPatch = true);
    }
}
