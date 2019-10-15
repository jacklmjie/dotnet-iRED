using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace iRED.Model
{
    [Table("WeiXinUsers")]
    public class WeiXinUser : TopBasePoco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int ID { get; set; }

        /// <summary>
        /// OpenId
        /// </summary>
        [Display(Name = "OpenId")]
        public string OpenId { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        [Display(Name = "创建时间")]
        public DateTime? CreateTime { get; set; }
    }
}
