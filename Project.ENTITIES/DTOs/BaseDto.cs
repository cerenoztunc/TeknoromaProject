using Project.COMMON.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.DTOs
{
    public class BaseDto
    {
        public virtual ResultStatus ResultStatus { get; set; }
    }
}
