using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Articles.Constants
{
    public enum ArticleStatus : byte
    {
        /// <summary>
        /// فعال
        /// </summary>
        [Display(Name = "فعال")]
        Active = 0,

        /// <summary>
        /// غیر فعال
        /// </summary>
        [Display(Name = "غیر فعال")]
        InActive = 1
    }
}
