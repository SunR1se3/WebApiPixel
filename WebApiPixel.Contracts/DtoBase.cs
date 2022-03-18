using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiPixel.Contracts
{
    /// <summary>
    /// Базовый класс ДТО
    /// </summary>
    public class DtoBase
    {
        /// <summary>
        /// id
        /// </summary>
        public Guid Id { get; set; }
    }
}
