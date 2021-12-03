
using Project.COMMON.Entities.Concretes;
using Project.COMMON.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.COMMON.Results.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; }
        public string Message { get; }
        public Exception Exception { get; }
        public IEnumerable<ValidationError> ValidationErrors { get; set; } //IEnumerable yaptık çünkü dişarıdan bir ekleme yapılamasın. Örneğin ValidationErrors.Add() yapılamaz çünkü IEnumerable Add() metodunu desteklemez..
    }
}
