
namespace WCDPatcher.Core.DistroPatcher
{
    public static class DistroPatcher
    {
        /// <summary>
        /// The original hash for the Deoxys Distribution Cart
        /// </summary>
        public const string DISTRO_MD5_HASH = "CC30A203C5489440EA2315DB3C791866";
         /// <summary>
        /// Patches the distro with the new wondercard information
        /// </summary>
        /// <param name="WondercardFile">The wondercard location</param>
        /// <param name="Distro">The distro location</param>
        /// <param name="newDistro">The path to output the new distro to</param>
        /// <param name="Region">The GGID to use</param>
        /// <param name="Desc">The ROM description to alter.</param>
        /// <param name="gameALRegion">The game allowance ID</param>
        /// <param name="friendDistLimit">The amount of times the wondercard can be shared between friends</param>
        /// <param name="randomSeed">Adds a seed to last part of the header. Leave as 0 for no change</param>
        public static void PatchDistro(string WondercardFile, string Distro, string newDistro, string Region,
           string gameALRegion, string Desc, int friendDistLimit, int randomSeed)
        {
            if (!System.IO.File.Exists(WondercardFile)) { return; } if (!System.IO.File.Exists(Distro)) { return; }

            //Read the correct data arrays (copyb,wcard,distro)
            //Read the WCARD into an array
            byte[] wcard = Core.IO.Patcher.GetFileBytes(WondercardFile);
            //Use a file stream alternative in the future
            byte[] bdist = Core.IO.Patcher.GetFileBytes(Distro);
            //Read the WCARD header info (card id bug relevant)
            //WondercardPatcher.WondercardPatcher.SetGameAllowanceBlock(ref wcard, Mappings.LookupMapping(gameALRegion));



            { //Check correct file sizes
                if (!(bdist.Length == 8388608 || bdist.Length == 1550140))
                {
                    //continue, todo: implement appropiate error handler
                }
                //For untrimmed and trimmed (Tested with NDSTokyoTrim)
                if (!(wcard.Length == 856)) return; //File sizes
            }

            if (Desc.Length < 128 && Desc.Length > 0)
            {
                Desc = Desc.Replace("\r\n", "\n");
                
                IO.Patcher.WriteDataInBuffer(bdist,ConvertDescriptionBytes(Desc), Core.DistroPatcher.DistroOffsets.DescriptionOffsets.eng_desc);
                IO.Patcher.WriteDataInBuffer(bdist,ConvertDescriptionBytes(Desc), Core.DistroPatcher.DistroOffsets.DescriptionOffsets.jap_desc);
                IO.Patcher.WriteDataInBuffer(bdist,ConvertDescriptionBytes(Desc), Core.DistroPatcher.DistroOffsets.DescriptionOffsets.ita_desc);
                IO.Patcher.WriteDataInBuffer(bdist,ConvertDescriptionBytes(Desc), Core.DistroPatcher.DistroOffsets.DescriptionOffsets.frn_desc);
                IO.Patcher.WriteDataInBuffer(bdist,ConvertDescriptionBytes(Desc), Core.DistroPatcher.DistroOffsets.DescriptionOffsets.spn_desc);
                IO.Patcher.WriteDataInBuffer(bdist,ConvertDescriptionBytes(Desc), Core.DistroPatcher.DistroOffsets.DescriptionOffsets.ger_desc);

            } //if the rom desc is too long, do not write it



            Core.WondercardPatcher.WondercardPatcher.ChangeFriendDistributionLimit((friendDistLimit), ref wcard);


            byte[] ggid_data = null;

            switch (Region.ToLower())
            {
                    
                case "英语": ggid_data = Core.WondercardPatcher.WondercardData.GGID_English; break;
                case "日语": ggid_data = Core.WondercardPatcher.WondercardData.GGID_Japanese; break;
                case "西班牙语": ggid_data = Core.WondercardPatcher.WondercardData.GGID_Spanish; break;
                case "韩语": ggid_data = Core.WondercardPatcher.WondercardData.GGID_Korean; break;
                case "意大利语": ggid_data = Core.WondercardPatcher.WondercardData.GGID_Italian; break;
                case "德语": ggid_data = Core.WondercardPatcher.WondercardData.GGID_German; break;
                case "法语": ggid_data = Core.WondercardPatcher.WondercardData.GGID_French; break;

                default: ggid_data = Core.WondercardPatcher.WondercardData.GGID_English;
                    break;
            }




           

            Core.IO.Patcher.WriteDataInBuffer(bdist, ggid_data, WondercardPatcher.WondercardOffsets.GGID); //write the GGID

            Core.IO.Patcher.WriteDataInBuffer(bdist, WondercardPatcher.WondercardData.DistributionDateStart,
                WondercardPatcher.WondercardOffsets.DateDistributionOffsetStart);

            Core.IO.Patcher.WriteDataInBuffer(bdist, WondercardPatcher.WondercardData.DistributionDateEnd,
                WondercardPatcher.WondercardOffsets.DateDistributionOffsetStart + 4); //Write the end date

            //Patch to modify the game allowance block
            WondercardPatcher.WondercardPatcher.SetGameAllowanceBlock(ref wcard, Mappings.LookupMapping(gameALRegion));


            byte[] copyb = Core.IO.Patcher.ReadDataFromArray(wcard,
                WondercardPatcher.WondercardOffsets.SourceCopyBlock, 80); //read the patched header

            int rndSeed = randomSeed;
            if (randomSeed > 254 | randomSeed < 0) rndSeed = 0;

            byte rndSeedByte = (byte)rndSeed;

            if (!(rndSeed == 0))
            {
                copyb[79] = rndSeedByte;
            }

           
            //Writing the WCARD header to ROM
            Core.IO.Patcher.WriteDataInBuffer(bdist, copyb, Core.DistroPatcher.DistroOffsets.HeaderDestinationOne);//writing the data into the distribution rom
            Core.IO.Patcher.WriteDataInBuffer(bdist, copyb, Core.DistroPatcher.DistroOffsets.HeaderDestinationTwo);


            //Insert the wondercard and patch other fields
            Core.IO.Patcher.WriteDataInBuffer(bdist, wcard, Core.DistroPatcher.DistroOffsets.WonderCardPosition); //Write the wondercard
            Core.IO.Patcher.WriteDataInBuffer(bdist, new byte[] { 0x0, 0x0 }, Core.DistroPatcher.DistroOffsets.TwoZerosOffset); //Some zeroes
            Core.IO.Patcher.WriteBufferToFile(newDistro, bdist);
            NDSUtilities.FixAllCRC(newDistro);

            wcard = null; bdist = null; copyb = null;
        }

        /// <summary>
        /// Pads text to work in the descriptions, and returns the description in bytes
        /// </summary>
        /// <param name="Text">The text to pad</param>
        /// <returns></returns>
        public static byte[] ConvertDescriptionBytes(string Text)
        {
            int max_desc_bytes = 256;
            int max_text_bytes = max_desc_bytes / 2; //128

            byte[] final = new byte[max_desc_bytes];

            if (Text.Length > max_text_bytes) return final; //Format is A.B.C. so only half of 256 bytes is available
            char[] charbuf = new char[max_desc_bytes];
            Text.ToCharArray().CopyTo(charbuf, 0);

            int count = 0;
            for (int i = 0; i < max_desc_bytes; i += 2)
            {
                final[i] = (byte)charbuf[count];
                count++;

            }

            return final;
        }
    }
}
