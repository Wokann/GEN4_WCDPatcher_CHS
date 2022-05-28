
using WCDPatcher.Core.IO;
namespace WCDPatcher.Core.WondercardPatcher
{
    public static class WondercardPatcher
    {
        
        public static void SetGameAllowanceBlock(ref byte[] wcard, byte[] twoByteBlock)
        {

            {
                //If the user does not specify a value, leave the wcard value untouched
                if (twoByteBlock == null) return;
                if (twoByteBlock.Length > 2) return;
            }

            //Write the new region/game allowance block into the WCARD header
            Patcher.WriteDataInBuffer(wcard, twoByteBlock, WondercardOffsets.PCDHeader_GameAllowanceBlock);
        }

        /// <summary>
        /// Changes the limit of times distributed to friends
        /// </summary>
        /// <param name="limit">the limit</param>
        /// <param name="wcard">the wondercard in memory to patch</param>
        public static void ChangeFriendDistributionLimit(int limit, ref byte[] wcard)
        {
            //Unlimited is 255, i think
            if (limit > 255) return;
            if (limit < 0) return;
            byte limBit = byte.Parse(limit.ToString());


            wcard[WondercardOffsets.FriendDistributionLimit] = limBit;
        }
    }
}
