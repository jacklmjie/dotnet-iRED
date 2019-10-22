using System;

namespace iRED.ViewModel.Helpers
{
    [Serializable]
    public class DecodeEntityBase
    {
        public Watermark watermark { get; set; }
    }

    /// <summary>
    /// 水印
    /// </summary>
    [Serializable]
    public class Watermark
    {
        public string appid { get; set; }
        public long timestamp { get; set; }
    }
}
